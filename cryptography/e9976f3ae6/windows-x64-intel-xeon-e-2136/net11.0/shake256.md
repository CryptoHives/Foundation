| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     439.2 ns |     1.21 ns |     1.01 ns |  16,508 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128B         |     541.1 ns |     1.28 ns |     1.20 ns |  16,262 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     604.8 ns |     2.01 ns |     1.68 ns |  14,668 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128B         |     841.4 ns |     2.14 ns |     1.79 ns |   4,275 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     835.3 ns |     2.20 ns |     1.95 ns |  16,491 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 137B         |   1,078.9 ns |     4.15 ns |     3.88 ns |   9,726 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |   1,133.3 ns |     1.36 ns |     1.21 ns |  16,025 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 137B         |   1,369.4 ns |     5.93 ns |     5.55 ns |   4,275 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   3,303.8 ns |     3.18 ns |     2.49 ns |  16,323 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1KB          |   4,179.6 ns |     9.67 ns |     8.57 ns |  16,264 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   4,447.6 ns |     3.82 ns |     3.39 ns |  16,178 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1KB          |   4,720.7 ns |    22.31 ns |    20.87 ns |  10,610 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   3,320.5 ns |    11.53 ns |    10.78 ns |  16,504 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1025B        |   4,424.6 ns |     6.40 ns |     5.99 ns |  16,077 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   4,447.0 ns |     3.11 ns |     2.91 ns |   9,653 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1025B        |   4,696.0 ns |     3.01 ns |     2.35 ns |  10,610 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |  24,656.6 ns |    34.72 ns |    28.99 ns |   9,973 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 8KB          |  31,537.2 ns |    29.39 ns |    27.49 ns |   9,748 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |  33,583.0 ns |    23.08 ns |    20.46 ns |   9,645 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 8KB          |  34,175.5 ns |   188.81 ns |   167.38 ns |  10,800 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 387,433.4 ns |    48.03 ns |    40.10 ns |  16,504 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128KB        | 496,142.5 ns |   976.03 ns |   912.97 ns |  16,258 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 529,745.8 ns |   665.28 ns |   589.75 ns |   9,655 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128KB        | 535,813.8 ns | 2,988.89 ns | 2,795.81 ns |   4,275 B |         - |