| Description                                      | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     1.026 μs |  0.0085 μs |  0.0080 μs |   9,487 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     1.678 μs |  0.0117 μs |  0.0110 μs |   4,309 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     1.024 μs |  0.0068 μs |  0.0064 μs |   9,503 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     1.683 μs |  0.0067 μs |  0.0056 μs |   4,297 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |     5.811 μs |  0.0407 μs |  0.0381 μs |   9,499 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |     9.211 μs |  0.0828 μs |  0.0775 μs |   4,309 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |     5.799 μs |  0.0436 μs |  0.0407 μs |   9,500 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |     9.230 μs |  0.0698 μs |  0.0619 μs |   4,302 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |    43.307 μs |  0.3319 μs |  0.3104 μs |   9,511 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |    69.071 μs |  0.5776 μs |  0.4823 μs |   4,309 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        |   687.685 μs |  4.3311 μs |  4.0513 μs |   9,462 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 1,107.905 μs | 19.0817 μs | 17.8491 μs |   4,319 B |         - |