| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     355.3 ns |   0.45 ns |   0.42 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     371.5 ns |   0.17 ns |   0.15 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     441.1 ns |   1.32 ns |   1.17 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     357.9 ns |   0.45 ns |   0.40 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     371.6 ns |   0.15 ns |   0.13 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     425.0 ns |   1.06 ns |   0.99 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,519.7 ns |   3.25 ns |   3.04 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   2,011.6 ns |   4.19 ns |   3.92 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,165.5 ns |   1.70 ns |   1.59 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,520.7 ns |   4.75 ns |   4.45 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   2,012.8 ns |   5.46 ns |   5.10 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,166.7 ns |   0.91 ns |   0.81 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |  10,138.4 ns |  43.04 ns |  40.26 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  15,282.3 ns |  18.79 ns |  17.58 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  16,528.4 ns |  10.13 ns |   8.98 ns |         - |
|                                           |              |              |           |           |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 157,705.7 ns | 588.70 ns | 550.67 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 242,619.6 ns | 258.91 ns | 216.21 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 262,630.8 ns | 194.79 ns | 172.67 ns |         - |