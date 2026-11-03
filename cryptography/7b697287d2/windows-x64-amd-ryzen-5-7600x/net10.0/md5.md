| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     307.4 ns |   0.42 ns |   0.39 ns |   2,773 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     315.2 ns |   0.24 ns |   0.21 ns |   4,441 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     431.8 ns |   0.48 ns |   0.45 ns |   5,112 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     312.3 ns |   0.46 ns |   0.43 ns |   2,761 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     313.8 ns |   0.30 ns |   0.27 ns |   4,441 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     430.9 ns |   0.35 ns |   0.32 ns |   5,113 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,602.1 ns |   0.58 ns |   0.54 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   1,683.8 ns |   0.79 ns |   0.61 ns |   2,773 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,353.0 ns |   3.45 ns |   3.22 ns |   5,128 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,601.2 ns |   0.43 ns |   0.40 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   1,689.3 ns |   1.61 ns |   1.50 ns |   2,766 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,349.0 ns |   2.44 ns |   2.28 ns |   5,117 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  11,882.6 ns |   4.04 ns |   3.58 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  12,684.6 ns |   7.93 ns |   6.62 ns |   2,775 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  17,701.6 ns |  22.87 ns |  21.39 ns |   5,138 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 188,143.0 ns |  44.19 ns |  41.34 ns |   4,441 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 201,329.7 ns | 174.46 ns | 163.19 ns |   2,773 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 280,794.3 ns | 415.11 ns | 388.30 ns |   5,087 B |         - |