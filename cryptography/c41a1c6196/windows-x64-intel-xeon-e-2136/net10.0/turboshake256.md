| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     250.0 ns |     2.14 ns |     2.00 ns |   5,625 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128B         |     294.8 ns |     1.23 ns |     1.15 ns |   5,398 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |     462.9 ns |     1.40 ns |     1.24 ns |   5,588 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 137B         |     564.9 ns |     2.50 ns |     2.21 ns |   5,361 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |   1,820.2 ns |    29.03 ns |    27.16 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1KB          |   2,198.0 ns |     6.51 ns |     6.09 ns |   5,386 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |   1,801.3 ns |    15.80 ns |    14.78 ns |   5,613 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1025B        |   2,310.1 ns |     6.58 ns |     6.16 ns |   5,366 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  13,344.8 ns |    89.34 ns |    83.57 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 8KB          |  16,482.7 ns |    65.99 ns |    61.72 ns |   5,363 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 209,323.1 ns | 1,506.92 ns | 1,409.57 ns |   5,591 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128KB        | 261,279.4 ns |   949.76 ns |   888.40 ns |   5,364 B |         - |