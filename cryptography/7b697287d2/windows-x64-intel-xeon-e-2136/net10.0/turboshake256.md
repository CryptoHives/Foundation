| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     246.6 ns |   0.36 ns |   0.30 ns |   5,625 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128B         |     295.8 ns |   1.18 ns |   1.11 ns |   5,378 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |     467.0 ns |   0.82 ns |   0.69 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 137B         |     572.4 ns |   0.75 ns |   0.66 ns |   5,365 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |   1,802.6 ns |   8.31 ns |   7.77 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1KB          |   2,204.7 ns |   9.63 ns |   9.01 ns |   5,366 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |   1,802.7 ns |  11.26 ns |   9.98 ns |   5,593 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1025B        |   2,198.9 ns |   9.87 ns |   9.24 ns |   5,366 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  13,339.9 ns |  16.23 ns |  13.55 ns |   5,592 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 8KB          |  16,616.3 ns |  36.02 ns |  33.69 ns |   5,363 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 208,088.8 ns | 175.57 ns | 164.23 ns |   5,591 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128KB        | 261,662.4 ns | 931.28 ns | 871.12 ns |   5,364 B |         - |