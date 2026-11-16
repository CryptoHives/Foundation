| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     326.4 ns |     1.37 ns |     1.28 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     354.7 ns |     1.43 ns |     1.34 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     415.3 ns |     0.69 ns |     0.65 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     327.9 ns |     0.98 ns |     0.92 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     352.0 ns |     0.91 ns |     0.85 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     397.7 ns |     0.41 ns |     0.39 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,387.8 ns |     1.87 ns |     1.75 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,836.6 ns |     2.20 ns |     1.95 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,025.7 ns |    15.24 ns |    14.26 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,386.8 ns |     1.22 ns |     1.14 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,837.6 ns |     3.93 ns |     3.68 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,025.4 ns |     7.11 ns |     6.65 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,267.6 ns |    28.03 ns |    26.22 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  13,983.7 ns |    30.63 ns |    28.65 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  15,458.5 ns |    88.45 ns |    82.73 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 143,797.5 ns |   429.25 ns |   401.52 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 222,382.9 ns |   489.91 ns |   458.27 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 245,592.6 ns | 1,374.79 ns | 1,285.98 ns |         - |