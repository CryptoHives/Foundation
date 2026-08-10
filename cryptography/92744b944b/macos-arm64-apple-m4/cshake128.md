| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     179.5 ns |     1.21 ns |     1.08 ns |     179.1 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     259.5 ns |     3.68 ns |     2.87 ns |     259.8 ns |         - |
|                                                 |              |              |             |             |              |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     181.2 ns |     1.43 ns |     1.20 ns |     181.0 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     243.2 ns |     4.80 ns |     4.26 ns |     244.3 ns |         - |
|                                                 |              |              |             |             |              |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,135.8 ns |    19.75 ns |    18.47 ns |   1,132.3 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,413.5 ns |    14.02 ns |    10.94 ns |   1,413.2 ns |         - |
|                                                 |              |              |             |             |              |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,115.0 ns |     2.89 ns |     2.41 ns |   1,114.0 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,408.6 ns |     9.69 ns |     8.09 ns |   1,409.9 ns |         - |
|                                                 |              |              |             |             |              |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,666.8 ns |    25.40 ns |    19.83 ns |   7,656.9 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,970.8 ns |    12.45 ns |    11.64 ns |   7,967.7 ns |         - |
|                                                 |              |              |             |             |              |           |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 122,230.4 ns |   497.16 ns |   465.05 ns | 122,058.4 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 127,380.1 ns | 2,540.76 ns | 3,477.82 ns | 125,383.0 ns |         - |