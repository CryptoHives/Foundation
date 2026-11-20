| Description                                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128B         |     254.3 ns |   0.93 ns |   0.82 ns |   9,977 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128B         |     333.4 ns |   0.65 ns |   0.61 ns |  16,081 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 137B         |     250.7 ns |   2.24 ns |   2.10 ns |   9,977 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 137B         |     301.6 ns |   1.23 ns |   1.09 ns |  16,262 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1KB          |   1,576.5 ns |   4.51 ns |   4.22 ns |  16,317 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1KB          |   1,945.2 ns |   4.64 ns |   4.34 ns |   9,733 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1025B        |   1,578.6 ns |   6.98 ns |   6.53 ns |  16,317 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1025B        |   1,946.5 ns |   2.43 ns |   2.27 ns |  16,068 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 8KB          |  10,778.9 ns |   5.45 ns |   4.83 ns |  16,317 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 8KB          |  13,555.1 ns |  21.86 ns |  19.38 ns |  16,068 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128KB        | 170,413.2 ns |  65.69 ns |  58.23 ns |   9,973 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128KB        | 212,784.5 ns | 189.30 ns | 158.07 ns |   9,733 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128B         |     257.8 ns |   1.22 ns |   1.14 ns |  16,321 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128B         |     300.8 ns |   0.25 ns |   0.23 ns |   9,737 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 137B         |     254.0 ns |   0.86 ns |   0.81 ns |  16,312 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 137B         |     306.4 ns |   0.43 ns |   0.36 ns |  16,072 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1KB          |   1,573.9 ns |   1.92 ns |   1.70 ns |   9,982 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1KB          |   2,144.8 ns |   3.49 ns |   3.26 ns |  16,068 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1025B        |   1,577.8 ns |   2.63 ns |   2.33 ns |  16,308 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1025B        |   2,161.2 ns |   4.95 ns |   4.63 ns |   9,742 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 8KB          |  10,771.1 ns |   3.12 ns |   2.77 ns |  16,498 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 8KB          |  13,474.2 ns |   7.54 ns |   6.68 ns |  16,068 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128KB        | 170,593.1 ns |  74.15 ns |  69.36 ns |   9,982 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128KB        | 232,173.7 ns | 483.44 ns | 452.21 ns |   9,733 B |         - |