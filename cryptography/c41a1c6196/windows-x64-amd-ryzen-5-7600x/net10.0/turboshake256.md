| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     138.9 ns |     1.96 ns |     1.83 ns |   5,589 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     173.1 ns |     1.64 ns |     1.54 ns |   5,078 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     179.2 ns |     0.18 ns |     0.15 ns |   4,093 B |         - |
|                                                      |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     260.4 ns |     0.94 ns |     0.83 ns |   5,565 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     329.1 ns |     2.65 ns |     2.48 ns |   5,056 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     347.4 ns |     3.14 ns |     2.93 ns |   4,073 B |         - |
|                                                      |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     992.5 ns |     3.63 ns |     3.04 ns |   5,577 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,258.4 ns |     8.60 ns |     7.62 ns |   5,064 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,314.6 ns |    15.36 ns |    14.36 ns |   4,077 B |         - |
|                                                      |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     991.8 ns |     2.44 ns |     2.16 ns |   5,573 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,259.3 ns |     1.11 ns |     0.98 ns |   5,068 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,304.0 ns |     0.64 ns |     0.53 ns |   4,077 B |         - |
|                                                      |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   7,485.4 ns |     9.95 ns |     8.82 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   9,403.3 ns |     7.30 ns |     6.83 ns |   5,063 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   9,815.6 ns |     6.29 ns |     5.25 ns |   4,076 B |         - |
|                                                      |              |              |             |             |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 117,762.9 ns |   517.87 ns |   432.45 ns |   5,571 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 149,699.1 ns |   105.59 ns |    93.61 ns |   5,062 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 156,713.7 ns | 1,737.71 ns | 1,625.46 ns |   4,075 B |         - |