| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3Native       | 128B         |     100.5 ns |     0.04 ns |     0.04 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |     243.1 ns |     0.02 ns |     0.02 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |     518.8 ns |     2.02 ns |     1.89 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |     721.3 ns |     3.49 ns |     3.09 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 137B         |     147.5 ns |     0.49 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |     365.6 ns |     0.02 ns |     0.02 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |     773.1 ns |     3.26 ns |     3.05 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |   1,065.8 ns |     4.53 ns |     4.01 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1KB          |     765.7 ns |     2.52 ns |     2.35 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |   1,960.6 ns |     0.12 ns |     0.10 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |   4,050.0 ns |    17.08 ns |    15.98 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |   5,327.4 ns |    14.12 ns |    13.21 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1025B        |     873.2 ns |     2.54 ns |     2.37 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |   2,200.2 ns |     0.26 ns |     0.20 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |   4,550.4 ns |    26.60 ns |    24.89 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |   6,068.1 ns |    17.69 ns |    16.54 ns |      56 B |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 8KB          |   3,379.5 ns |    36.28 ns |    47.18 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |  17,220.6 ns |     6.49 ns |     5.42 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |  33,848.5 ns |   241.04 ns |   225.47 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |  45,220.0 ns |   154.37 ns |   144.40 ns |     392 B |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 128KB        |  52,635.9 ns |   205.90 ns |   182.52 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        | 283,197.0 ns | 2,381.90 ns | 1,988.99 ns |      24 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        | 561,904.6 ns | 2,318.77 ns | 2,055.53 ns |      24 B |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        | 729,030.9 ns | 1,957.62 ns | 1,634.70 ns |    7112 B |