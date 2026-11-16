| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     435.2 ns |     1.25 ns |     1.04 ns |   5,639 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128B         |     543.6 ns |     2.72 ns |     2.54 ns |   5,432 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     607.9 ns |     1.41 ns |     1.17 ns |   7,679 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     839.8 ns |     3.70 ns |     3.46 ns |   5,620 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 137B         |   1,090.2 ns |     4.12 ns |     3.85 ns |   5,395 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |   1,146.5 ns |     2.15 ns |     2.02 ns |   8,969 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   3,321.7 ns |    13.30 ns |    12.45 ns |   5,627 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1KB          |   4,188.1 ns |    23.40 ns |    21.89 ns |   5,400 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   4,476.3 ns |     9.67 ns |     9.04 ns |   8,927 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   3,307.1 ns |     6.16 ns |     5.14 ns |   5,649 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1025B        |   4,317.5 ns |    15.59 ns |    14.58 ns |   5,400 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   4,460.4 ns |     7.63 ns |     7.14 ns |   8,956 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |  24,683.0 ns |   102.84 ns |    96.20 ns |   5,624 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 8KB          |  32,363.4 ns |   102.04 ns |    95.45 ns |   5,397 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |  33,581.6 ns |    31.47 ns |    29.43 ns |   8,941 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 389,147.0 ns | 1,214.81 ns | 1,136.33 ns |   5,625 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128KB        | 499,396.7 ns | 2,637.20 ns | 2,466.84 ns |   5,398 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 529,804.1 ns |   481.21 ns |   450.12 ns |   8,945 B |         - |