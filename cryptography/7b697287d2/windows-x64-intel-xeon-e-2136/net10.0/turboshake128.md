| Description                                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128B         |     255.4 ns |   0.55 ns |   0.46 ns |   5,629 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128B         |     302.3 ns |   0.97 ns |   0.91 ns |   5,383 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 137B         |     251.0 ns |   0.16 ns |   0.14 ns |   5,610 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 137B         |     307.1 ns |   0.66 ns |   0.62 ns |   5,383 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1KB          |   1,577.9 ns |   2.59 ns |   2.30 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1KB          |   1,953.3 ns |   2.53 ns |   2.24 ns |   5,367 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1025B        |   1,573.1 ns |   1.22 ns |   1.14 ns |   5,594 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1025B        |   1,952.7 ns |   6.70 ns |   5.59 ns |   5,367 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 8KB          |  10,800.9 ns |  14.72 ns |  12.29 ns |   5,598 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 8KB          |  13,443.3 ns |  37.65 ns |  35.22 ns |   5,371 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128KB        | 170,526.7 ns | 125.02 ns | 110.82 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128KB        | 213,858.6 ns | 410.01 ns | 383.53 ns |   5,365 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128B         |     251.5 ns |   0.85 ns |   0.80 ns |   5,625 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128B         |     303.1 ns |   0.89 ns |   0.83 ns |   5,383 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 137B         |     252.2 ns |   0.24 ns |   0.22 ns |   5,607 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 137B         |     308.6 ns |   0.83 ns |   0.69 ns |   5,400 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1KB          |   1,572.7 ns |   2.48 ns |   2.32 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1KB          |   1,974.9 ns |   4.16 ns |   3.89 ns |   5,363 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1025B        |   1,574.8 ns |   2.15 ns |   1.91 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1025B        |   1,954.6 ns |   6.21 ns |   5.81 ns |   5,365 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 8KB          |  10,802.7 ns |  21.90 ns |  20.49 ns |   5,613 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 8KB          |  13,490.5 ns |  22.48 ns |  21.03 ns |   5,388 B |         - |
|                                                        |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128KB        | 170,365.5 ns |  99.11 ns |  92.70 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128KB        | 214,791.3 ns | 317.98 ns | 281.88 ns |   5,363 B |         - |