| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     435.4 ns |     0.58 ns |     0.48 ns |   5,639 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128B         |     547.4 ns |     0.76 ns |     0.67 ns |   5,432 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     608.0 ns |     1.54 ns |     1.37 ns |   7,679 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     835.2 ns |     2.06 ns |     1.93 ns |   5,622 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 137B         |   1,068.3 ns |     2.95 ns |     2.76 ns |   5,395 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |   1,150.8 ns |     0.73 ns |     0.64 ns |   8,980 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   3,314.1 ns |     3.25 ns |     2.71 ns |   5,627 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1KB          |   4,213.5 ns |     9.60 ns |     8.98 ns |   5,400 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   4,467.4 ns |     5.40 ns |     5.05 ns |   8,951 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   3,312.7 ns |     2.87 ns |     2.68 ns |   5,649 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1025B        |   4,202.0 ns |    11.45 ns |    10.15 ns |   5,400 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   4,475.1 ns |     4.10 ns |     3.42 ns |   8,954 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |  24,638.1 ns |    17.48 ns |    15.50 ns |   5,624 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 8KB          |  32,002.2 ns |    65.41 ns |    61.19 ns |   5,397 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |  33,684.0 ns |    72.62 ns |    64.38 ns |   8,960 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 387,681.3 ns |   287.89 ns |   255.21 ns |   5,625 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128KB        | 503,651.9 ns | 1,668.91 ns | 1,561.10 ns |   5,398 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 531,384.3 ns |   459.56 ns |   407.39 ns |   8,945 B |         - |