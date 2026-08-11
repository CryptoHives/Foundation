| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · OS Native          | 128B         |     270.2 ns |   0.38 ns |   0.32 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     271.3 ns |   0.31 ns |   0.28 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     379.9 ns |   0.45 ns |   0.39 ns |   6,913 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 137B         |     268.5 ns |   0.68 ns |   0.63 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     276.2 ns |   0.57 ns |   0.50 ns |   4,400 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     381.1 ns |   0.77 ns |   0.72 ns |   6,914 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,371.4 ns |   3.11 ns |   2.91 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,480.7 ns |   2.47 ns |   2.19 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,030.0 ns |   6.10 ns |   4.76 ns |   6,929 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,370.1 ns |   1.36 ns |   1.14 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,492.1 ns |   4.18 ns |   3.91 ns |   4,405 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,032.6 ns |   3.88 ns |   3.44 ns |   6,916 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,175.9 ns |  19.64 ns |  17.41 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  11,199.4 ns |  23.91 ns |  22.36 ns |   4,412 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,228.8 ns |  27.25 ns |  25.49 ns |   6,927 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 161,166.7 ns | 291.04 ns | 272.24 ns |   4,280 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 178,038.3 ns | 462.93 ns | 433.03 ns |   4,422 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 241,841.6 ns | 337.45 ns | 299.14 ns |   6,874 B |         - |