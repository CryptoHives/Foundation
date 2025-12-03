// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

/// <summary>
/// Defines a contract for providing pooled, reusable manual-reset value task
/// sources for asynchronous operations of type <typeparamref name="T"/>.
/// </summary>
public interface IGetPooledManualResetValueTaskSource<T>
{
    /// <summary>
    /// Retrieves a pooled instance of a manual reset value task source associated with the specified owner.
    /// </summary>
    /// <remarks>
    /// In addition to the base Get() behavior, this method sets the owner pool and the owner of the retrieved instance.
    /// The returned instance is obtained from a pool and may be reused. The value is implicitly returned
    /// to the owner pool when the operation is complete and the result has been retrieved.
    /// The owner is needed for efficient implementation of cancellation token registration callbacks.
    /// The CancellationToken property of the returned instance is not initialized.
    /// The CancellationTokenRegistration property of the returned instance is initially set to default.
    /// The UseContinuationAsynchronously property of the returned instance is unspecified.
    /// </remarks>
    /// <param name="owner">The object that will be associated with the returned pooled waiter. Cannot be null.</param>
    /// <returns>A pooled manual reset value task source of type T that is associated with the specified owner.</returns>
    PooledManualResetValueTaskSource<T> GetPooledWaiter(object owner);
}
