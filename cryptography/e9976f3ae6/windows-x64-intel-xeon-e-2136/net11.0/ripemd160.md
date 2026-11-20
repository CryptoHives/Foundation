| Description                                      | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     1.032 μs |  0.0068 μs |  0.0064 μs |   9,405 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     1.655 μs |  0.0063 μs |  0.0059 μs |   6,844 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     1.034 μs |  0.0084 μs |  0.0079 μs |   9,406 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     1.664 μs |  0.0094 μs |  0.0083 μs |  13,167 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |     5.832 μs |  0.0290 μs |  0.0271 μs |   9,406 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |     9.144 μs |  0.0651 μs |  0.0609 μs |   6,844 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |     5.899 μs |  0.0258 μs |  0.0241 μs |   9,407 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |     9.080 μs |  0.0893 μs |  0.0835 μs |  13,360 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |    44.298 μs |  0.2360 μs |  0.2208 μs |   9,418 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |    68.520 μs |  0.8564 μs |  0.8011 μs |  13,179 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        |   705.167 μs |  0.2794 μs |  0.2477 μs |   9,763 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 1,088.625 μs | 13.9677 μs | 13.0654 μs |  13,189 B |         - |