| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     1.037 μs | 0.0013 μs | 0.0012 μs |   9,487 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     1.684 μs | 0.0035 μs | 0.0032 μs |   4,309 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     1.036 μs | 0.0018 μs | 0.0017 μs |   9,495 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     1.678 μs | 0.0032 μs | 0.0027 μs |   4,297 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |     5.858 μs | 0.0079 μs | 0.0070 μs |   9,495 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |     9.127 μs | 0.0191 μs | 0.0170 μs |   4,309 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |     5.839 μs | 0.0077 μs | 0.0069 μs |   9,504 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |     9.163 μs | 0.0385 μs | 0.0360 μs |   4,302 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |    43.765 μs | 0.0899 μs | 0.0841 μs |   9,511 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |    68.741 μs | 0.1889 μs | 0.1674 μs |   4,309 B |         - |
|                                                  |              |              |           |           |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        |   693.969 μs | 1.4272 μs | 1.3350 μs |   9,462 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 1,091.754 μs | 3.8227 μs | 3.5758 μs |   4,319 B |         - |