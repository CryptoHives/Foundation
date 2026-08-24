| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     265.8 ns |   0.64 ns |   0.57 ns |   4,412 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     268.5 ns |   0.35 ns |   0.31 ns |   4,280 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     379.1 ns |   0.70 ns |   0.65 ns |   6,913 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     267.1 ns |   0.62 ns |   0.55 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     271.3 ns |   0.15 ns |   0.13 ns |   4,400 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     380.2 ns |   0.35 ns |   0.33 ns |   6,912 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,366.5 ns |   1.16 ns |   0.97 ns |   4,352 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,458.6 ns |   1.77 ns |   1.48 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,026.1 ns |   2.47 ns |   2.31 ns |   6,929 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,368.8 ns |   1.68 ns |   1.40 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,467.0 ns |   6.05 ns |   5.36 ns |   4,405 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,022.4 ns |   5.83 ns |   5.45 ns |   6,914 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,151.8 ns |   8.98 ns |   8.40 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  11,016.1 ns |  15.58 ns |  12.16 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,132.5 ns |  15.97 ns |  14.16 ns |   6,757 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 160,822.7 ns | 138.83 ns | 129.86 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 174,912.6 ns | 322.04 ns | 285.48 ns |   4,422 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 240,125.6 ns | 244.51 ns | 228.71 ns |   6,874 B |         - |