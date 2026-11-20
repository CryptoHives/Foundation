| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     312.2 ns |   0.88 ns |   0.78 ns |  12,053 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     314.3 ns |   0.87 ns |   0.77 ns |  13,640 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     436.4 ns |   0.71 ns |   0.63 ns |   5,181 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     311.5 ns |   0.45 ns |   0.39 ns |  14,231 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     317.9 ns |   0.66 ns |   0.59 ns |  12,041 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     433.0 ns |   0.37 ns |   0.31 ns |   5,182 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,600.5 ns |   0.92 ns |   0.86 ns |   6,850 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,706.3 ns |   2.14 ns |   1.79 ns |  12,053 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,349.8 ns |   2.84 ns |   2.52 ns |   5,183 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,601.9 ns |   2.19 ns |   1.95 ns |   6,850 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,713.5 ns |   3.50 ns |   2.92 ns |  12,044 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,352.2 ns |   3.02 ns |   2.67 ns |   5,184 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  11,895.2 ns |   8.94 ns |   8.36 ns |   6,850 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  12,858.6 ns |  44.05 ns |  41.21 ns |  12,053 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  17,689.6 ns |  24.56 ns |  22.97 ns |   5,195 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 188,346.5 ns |  85.60 ns |  75.88 ns |  13,830 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 203,933.1 ns | 530.37 ns | 470.16 ns |  11,873 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 280,965.5 ns | 334.85 ns | 313.22 ns |   5,560 B |         - |