| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3Native       | 128B         |     101.7 ns |     0.19 ns |     0.18 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |     247.3 ns |     0.43 ns |     0.40 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |     514.9 ns |     2.62 ns |     2.33 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |     726.5 ns |     2.75 ns |     2.57 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 137B         |     147.9 ns |     0.60 ns |     0.56 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |     371.9 ns |     0.77 ns |     0.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |     765.5 ns |     2.90 ns |     2.71 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |   1,073.6 ns |     3.78 ns |     3.35 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1KB          |     771.9 ns |     3.18 ns |     2.82 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |   1,994.2 ns |     4.83 ns |     4.52 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |   3,933.9 ns |    24.13 ns |    22.58 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |   5,363.7 ns |    26.55 ns |    24.84 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1025B        |     881.0 ns |     3.02 ns |     2.83 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |   2,238.4 ns |     3.60 ns |     3.19 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |   4,584.5 ns |    17.72 ns |    15.71 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |   6,120.7 ns |    20.35 ns |    19.03 ns |      56 B |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 8KB          |   3,304.4 ns |    12.87 ns |    12.04 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |  17,542.1 ns |    74.48 ns |    69.67 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |  34,242.6 ns |   230.92 ns |   216.01 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |  45,147.6 ns |   183.34 ns |   171.49 ns |     392 B |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 128KB        |  52,182.4 ns |   207.42 ns |   194.02 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        | 285,292.2 ns |   882.20 ns |   825.21 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        | 552,471.3 ns | 2,326.83 ns | 2,176.52 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        | 725,677.2 ns | 2,436.17 ns | 2,278.80 ns |    7112 B |