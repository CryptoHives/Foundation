| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     265.8 ns |   1.51 ns |   1.34 ns |   4,412 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     270.9 ns |   0.75 ns |   0.66 ns |   4,352 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     382.3 ns |   0.91 ns |   0.80 ns |   6,913 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     269.5 ns |   1.05 ns |   0.99 ns |   4,400 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     270.1 ns |   0.73 ns |   0.64 ns |   4,352 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     379.9 ns |   0.53 ns |   0.44 ns |   6,914 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,372.8 ns |   3.12 ns |   2.92 ns |   4,352 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,451.0 ns |   4.57 ns |   4.27 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,029.7 ns |   4.26 ns |   3.56 ns |   6,929 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,374.2 ns |   4.01 ns |   3.75 ns |   4,352 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,455.9 ns |   4.22 ns |   3.29 ns |   4,405 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,033.0 ns |   4.75 ns |   4.21 ns |   6,914 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,195.6 ns |  24.74 ns |  23.14 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  10,926.0 ns |  35.86 ns |  33.55 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,206.1 ns |  47.56 ns |  42.16 ns |   6,757 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 161,202.0 ns | 222.10 ns | 207.75 ns |   4,352 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 173,590.9 ns | 438.35 ns | 388.59 ns |   4,422 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 241,699.3 ns | 889.05 ns | 831.62 ns |   6,874 B |         - |