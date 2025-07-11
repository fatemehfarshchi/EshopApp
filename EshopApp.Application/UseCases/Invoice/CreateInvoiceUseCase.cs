
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;
using EshopApp.Domain.Enums;
using EshopApp.Shared;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for creating a new invoice, including its items, in the system.
    /// </summary>
    public class CreateInvoiceUseCase
    {
        /// <summary>
        /// The repository for accessing and adding invoice data.
        /// </summary>
        private readonly IInvoiceRepository _InvoiceRepository;
        /// <summary>
        /// The repository for accessing and adding invoice item data.
        /// </summary>
        private readonly IInvoiceItemRepository _InvoiceItemRepository;
        /// <summary>
        /// The repository for accessing product data.
        /// </summary>
        private readonly IProductRepository _ProductRepository;
        /// <summary>
        /// The repository for accessing customer data.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceUseCase"/> class.
        /// </summary>
        /// <param name="invoiceRepository">The invoice repository dependency.</param>
        /// <param name="invoiceItemRepository">The invoice item repository dependency.</param>
        /// <param name="productRepository">The product repository dependency.</param>
        /// <param name="customerRepository">The customer repository dependency.</param>
        public CreateInvoiceUseCase(
            IInvoiceRepository invoiceRepository,
            IInvoiceItemRepository invoiceItemRepository,
            IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            _InvoiceRepository = invoiceRepository;
            _InvoiceItemRepository = invoiceItemRepository;
            _ProductRepository = productRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Creates a new invoice and its items using the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO containing invoice and item information.</param>
        /// <returns>An <see cref="OperationResult"/> indicating success or failure.</returns>
        public async Task<OperationResult> ExecuteAsync(CreateInvoiceDTO dto)
        {
            // Retrieve the customer by ID
            var customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
            if (customer == null)
                return OperationResult.Fail("Customer not found");

            // Create the invoice entity
            var invoice = new EshopApp.Domain.Entities.Invoice(customer, dto.Date, new List<InvoiceItem>());
            invoice.Status = InvoiceStatus.Draft;
            invoice.PaymentMethod = dto.PaymentMethod;

            // Add each invoice item and update product stock
            foreach (var itemdto in dto.Items)
            {
                var product = await _ProductRepository.GetByIdAsync(itemdto.ProductId);
                if (product == null)
                    return OperationResult.Fail("product not found!");

                var item = new InvoiceItem(product, itemdto.Quantity, itemdto.UnitPrice)
                {
                    Invoice = invoice
                };

                invoice.AddItem(item);

                await _ProductRepository.UpdateStockAsync(itemdto.ProductId, itemdto.Quantity);
            }

            // Persist the invoice
            await _InvoiceRepository.AddAsync(invoice);
            return OperationResult.Ok("Invoice created successfully");
        }
    }
}