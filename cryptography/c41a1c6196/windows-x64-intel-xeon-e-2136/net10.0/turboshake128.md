| Description                                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128B         |     252.5 ns |   1.14 ns |   0.95 ns |   5,629 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128B         |     300.8 ns |   1.73 ns |   1.62 ns |   5,383 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 137B         |     249.8 ns |   0.61 ns |   0.57 ns |   5,629 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 137B         |     306.1 ns |   0.89 ns |   0.83 ns |   5,383 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1KB          |   1,582.2 ns |  12.23 ns |  11.44 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1KB          |   1,954.7 ns |   6.64 ns |   6.21 ns |   5,365 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1025B        |   1,579.1 ns |   5.69 ns |   4.75 ns |   5,596 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1025B        |   1,971.0 ns |   8.17 ns |   7.65 ns |   5,367 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 8KB          |  10,813.2 ns |  30.96 ns |  27.45 ns |   5,598 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 8KB          |  13,596.1 ns |  41.08 ns |  38.43 ns |   5,394 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128KB        | 170,078.9 ns | 123.00 ns | 115.05 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128KB        | 215,826.8 ns | 689.02 ns | 644.51 ns |   5,365 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128B         |     252.4 ns |   2.08 ns |   1.94 ns |   5,625 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128B         |     297.9 ns |   1.69 ns |   1.58 ns |   5,383 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 137B         |     253.3 ns |   0.62 ns |   0.55 ns |   5,625 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 137B         |     298.2 ns |   1.48 ns |   1.38 ns |   5,380 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1KB          |   1,577.1 ns |   3.23 ns |   2.70 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1KB          |   1,977.3 ns |   8.07 ns |   7.54 ns |   5,365 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1025B        |   1,586.0 ns |   9.45 ns |   8.84 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1025B        |   1,979.4 ns |   7.53 ns |   7.04 ns |   5,365 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 8KB          |  10,795.9 ns |  26.86 ns |  23.81 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 8KB          |  13,407.6 ns |  50.70 ns |  47.42 ns |   5,366 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128KB        | 170,224.3 ns | 148.73 ns | 131.84 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128KB        | 213,897.2 ns | 641.15 ns | 599.74 ns |   5,363 B |         - |