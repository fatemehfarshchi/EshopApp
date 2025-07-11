public class OperationResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";

    public static OperationResult Ok(string message = "") =>
        new OperationResult { Success = true, Message = message };

    public static OperationResult Fail(string message) =>
        new OperationResult { Success = false, Message = message };
}

/// <summary>
/// Represents the result of an operation, including a value of type <typeparamref name="T"/>.
/// Inherits from <see cref="OperationResult"/>.
/// </summary>
/// <typeparam name="T">The type of the data returned by the operation.</typeparam>
public class OperationResult<T> : OperationResult
{
    /// <summary>
    /// Gets or sets the data returned by the operation.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Creates a successful <see cref="OperationResult{T}"/> with the specified data and optional message.
    /// </summary>
    /// <param name="data">The data to return with the result.</param>
    /// <param name="message">An optional message describing the result.</param>
    /// <returns>A successful <see cref="OperationResult{T}"/> instance.</returns>
    public static OperationResult<T> Ok(T data, string message = "") =>
        new OperationResult<T> { Success = true, Message = message, Data = data };

    /// <summary>
    /// Creates a failed <see cref="OperationResult{T}"/> with the specified error message.
    /// </summary>
    /// <param name="message">The error message describing the failure.</param>
    /// <returns>A failed <see cref="OperationResult{T}"/> instance.</returns>
    public new static OperationResult<T> Fail(string message) =>
        new OperationResult<T> { Success = false, Message = message };
}
