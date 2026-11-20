| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     251.5 ns |   1.41 ns |   1.32 ns |   9,986 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128B         |     296.9 ns |   0.59 ns |   0.55 ns |  16,262 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |     463.7 ns |   1.11 ns |   1.04 ns |  16,310 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 137B         |     581.1 ns |   1.11 ns |   1.04 ns |  16,061 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |   1,782.6 ns |   8.19 ns |   7.26 ns |  16,317 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1KB          |   2,207.4 ns |   5.47 ns |   5.12 ns |  16,267 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |   1,788.5 ns |   6.77 ns |   6.34 ns |  16,498 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 1025B        |   2,208.9 ns |   6.39 ns |   5.98 ns |   9,733 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  13,267.9 ns |  35.02 ns |  31.05 ns |  16,308 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 8KB          |  16,642.0 ns |  49.71 ns |  44.06 ns |  16,068 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 207,965.7 ns | 255.59 ns | 213.43 ns |  16,507 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2   | 128KB        | 261,159.9 ns | 634.00 ns | 529.42 ns |  16,267 B |         - |