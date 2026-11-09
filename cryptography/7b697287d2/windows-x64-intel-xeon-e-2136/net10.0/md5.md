| Description                               | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     354.6 ns |   0.94 ns |   0.88 ns |   2,791 B |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     377.9 ns |   1.41 ns |   1.32 ns |   4,450 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     469.4 ns |   1.54 ns |   1.44 ns |   5,118 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     353.4 ns |   1.36 ns |   1.27 ns |   2,779 B |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     380.7 ns |   1.09 ns |   0.91 ns |   4,450 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     481.9 ns |   2.42 ns |   2.27 ns |   5,117 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,778.5 ns |   4.03 ns |   3.77 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,031.2 ns |   8.65 ns |   8.09 ns |   2,791 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,656.6 ns |   9.32 ns |   8.72 ns |   5,118 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,779.3 ns |   4.25 ns |   3.98 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,025.1 ns |   9.39 ns |   8.79 ns |   2,784 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,628.0 ns |  10.06 ns |   9.41 ns |   5,122 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  12,680.7 ns |  44.49 ns |  37.15 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  14,853.1 ns |  30.95 ns |  28.95 ns |   2,791 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  19,684.5 ns |  62.58 ns |  58.53 ns |   4,971 B |         - |
|                                           |              |              |           |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 199,784.5 ns | 651.22 ns | 577.29 ns |   4,450 B |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 235,284.3 ns | 645.49 ns | 603.79 ns |   2,801 B |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 308,823.6 ns | 831.36 ns | 736.98 ns |   5,093 B |         - |