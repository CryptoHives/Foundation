| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     189.1 ns |     2.40 ns |     2.24 ns |   5,607 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128B         |     228.6 ns |     3.54 ns |     3.31 ns |   5,383 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |     353.4 ns |     4.88 ns |     4.57 ns |   5,588 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 137B         |     434.3 ns |     5.00 ns |     4.67 ns |   5,361 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |   1,373.8 ns |    19.77 ns |    18.49 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1KB          |   1,695.4 ns |    10.28 ns |     9.62 ns |   5,366 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |   1,369.7 ns |    19.48 ns |    18.22 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1025B        |   1,687.3 ns |    23.22 ns |    21.72 ns |   5,366 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  10,138.1 ns |    92.35 ns |    86.38 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 8KB          |  12,641.2 ns |   229.91 ns |   215.06 ns |   5,365 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 158,208.2 ns | 2,853.35 ns | 2,669.03 ns |   5,591 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128KB        | 199,792.4 ns | 2,832.12 ns | 2,649.17 ns |   5,364 B |         - |