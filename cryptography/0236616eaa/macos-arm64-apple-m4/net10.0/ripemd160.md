| Description                                      | TestDataSize | Mean       | Error     | StdDev    | Median     | Allocated |
|------------------------------------------------- |------------- |-----------:|----------:|----------:|-----------:|----------:|
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |   2.439 μs | 0.0012 μs | 0.0011 μs |   2.439 μs |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |   2.482 μs | 0.0088 μs | 0.0083 μs |   2.485 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |   2.468 μs | 0.0013 μs | 0.0011 μs |   2.468 μs |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |   2.486 μs | 0.0424 μs | 0.0397 μs |   2.454 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   2.971 μs | 0.0046 μs | 0.0043 μs |   2.970 μs |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   2.974 μs | 0.0588 μs | 0.0861 μs |   2.940 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   2.907 μs | 0.0008 μs | 0.0006 μs |   2.907 μs |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   2.947 μs | 0.0202 μs | 0.0179 μs |   2.939 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  21.930 μs | 0.0125 μs | 0.0098 μs |  21.932 μs |         - |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  22.249 μs | 0.1055 μs | 0.0987 μs |  22.230 μs |         - |
|                                                  |              |            |           |           |            |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 351.631 μs | 1.4869 μs | 1.3908 μs | 351.675 μs |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 353.564 μs | 0.4347 μs | 0.3630 μs | 353.512 μs |         - |