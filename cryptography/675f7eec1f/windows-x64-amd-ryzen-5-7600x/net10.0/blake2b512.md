| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      84.79 ns |     0.267 ns |     0.237 ns |   8,075 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      96.43 ns |     0.250 ns |     0.195 ns |   8,036 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     102.56 ns |     0.502 ns |     0.470 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     130.60 ns |     0.443 ns |     0.370 ns |  10,142 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     518.67 ns |     4.315 ns |     3.825 ns |   8,868 B |    1216 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     168.42 ns |     1.479 ns |     1.383 ns |   8,076 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     180.36 ns |     1.813 ns |     1.607 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     182.98 ns |     0.717 ns |     0.671 ns |   9,755 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     253.59 ns |     0.926 ns |     0.866 ns |  10,141 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     937.89 ns |     3.952 ns |     3.503 ns |   9,226 B |    1232 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     634.28 ns |     5.467 ns |     5.113 ns |   8,095 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     654.72 ns |     7.769 ns |     6.887 ns |   8,049 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     727.11 ns |     5.831 ns |     5.455 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     988.04 ns |     3.529 ns |     3.301 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,085.18 ns |    16.322 ns |    14.469 ns |   9,061 B |    2112 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     715.95 ns |     5.472 ns |     5.119 ns |   8,065 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     736.08 ns |     7.563 ns |     6.704 ns |   8,024 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     806.12 ns |     4.752 ns |     4.445 ns |   9,755 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,105.90 ns |     6.949 ns |     6.500 ns |  10,139 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,783.12 ns |    11.273 ns |     9.413 ns |   9,112 B |    2120 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   5,025.49 ns |    53.098 ns |    49.668 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,082.83 ns |    71.970 ns |    63.800 ns |   8,292 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,651.51 ns |    65.211 ns |    60.999 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   7,882.06 ns |    61.802 ns |    57.810 ns |  10,150 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  23,806.07 ns |   213.558 ns |   189.314 ns |   9,110 B |    9280 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  80,103.77 ns |   661.751 ns |   619.002 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  81,351.05 ns |   690.212 ns |   538.872 ns |   8,291 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  89,575.43 ns |   852.084 ns |   797.040 ns |   9,752 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 125,283.17 ns |   610.268 ns |   509.602 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 402,050.73 ns | 2,148.672 ns | 1,904.742 ns |   9,096 B |  132174 B |