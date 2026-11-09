| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128B         |     191.9 ns |     2.74 ns |     2.57 ns |   5,629 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128B         |     233.6 ns |     3.84 ns |     3.59 ns |   5,383 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 137B         |     192.1 ns |     3.27 ns |     3.06 ns |   5,610 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 137B         |     232.5 ns |     3.61 ns |     3.38 ns |   5,402 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1KB          |   1,203.3 ns |    13.79 ns |    12.90 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1KB          |   1,488.7 ns |    21.09 ns |    19.73 ns |   5,365 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 1025B        |   1,203.5 ns |    23.12 ns |    18.05 ns |   5,594 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 1025B        |   1,491.2 ns |    21.79 ns |    20.38 ns |   5,367 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 8KB          |   8,206.4 ns |   142.36 ns |   133.16 ns |   5,598 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 8KB          |  10,334.8 ns |    44.55 ns |    41.67 ns |   5,371 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-Scalar | 128KB        | 130,673.0 ns | 2,113.32 ns | 1,976.80 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-32 · CryptoHives-AVX2   | 128KB        | 162,625.7 ns | 2,813.39 ns | 2,631.65 ns |   5,365 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128B         |     191.0 ns |     2.64 ns |     2.47 ns |   5,625 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128B         |     234.4 ns |     3.52 ns |     3.30 ns |   5,400 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 137B         |     190.4 ns |     3.11 ns |     2.91 ns |   5,627 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 137B         |     234.0 ns |     3.90 ns |     3.64 ns |   5,378 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1KB          |   1,196.2 ns |    17.79 ns |    16.64 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1KB          |   1,487.7 ns |    23.16 ns |    21.67 ns |   5,363 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 1025B        |   1,207.7 ns |    17.36 ns |    16.23 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 1025B        |   1,496.7 ns |    16.16 ns |    15.12 ns |   5,365 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 8KB          |   8,204.9 ns |   142.70 ns |   133.48 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 8KB          |  10,296.8 ns |   152.21 ns |   142.38 ns |   5,371 B |         - |
|                                                        |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-Scalar | 128KB        | 129,649.9 ns | 1,994.83 ns | 1,865.96 ns |   5,590 B |         - |
| TryComputeHash · TurboSHAKE128-64 · CryptoHives-AVX2   | 128KB        | 162,750.4 ns | 2,683.97 ns | 2,510.59 ns |   5,363 B |         - |