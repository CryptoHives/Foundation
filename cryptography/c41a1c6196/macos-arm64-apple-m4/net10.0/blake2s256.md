| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |         73.94 ns |      0.156 ns |      0.146 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         79.42 ns |      0.346 ns |      0.324 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        106.77 ns |      0.095 ns |      0.089 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 4B           |        201.39 ns |      0.198 ns |      0.186 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         73.77 ns |      0.169 ns |      0.158 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         77.09 ns |      0.317 ns |      0.296 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        107.74 ns |      0.143 ns |      0.133 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64B          |        201.30 ns |      0.146 ns |      0.136 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        139.81 ns |      0.436 ns |      0.408 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        155.14 ns |      0.901 ns |      0.843 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        197.53 ns |      0.483 ns |      0.428 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 65B          |        405.28 ns |      0.338 ns |      0.316 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        139.66 ns |      0.557 ns |      0.521 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        154.08 ns |      0.647 ns |      0.605 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        197.30 ns |      0.173 ns |      0.145 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |        405.16 ns |      0.368 ns |      0.344 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        207.27 ns |      0.234 ns |      0.219 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        231.46 ns |      0.825 ns |      0.771 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        286.51 ns |      0.517 ns |      0.484 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 129B         |        607.83 ns |      2.647 ns |      2.476 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,081.41 ns |      4.266 ns |      3.991 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,220.64 ns |      6.935 ns |      6.487 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,462.72 ns |      2.423 ns |      2.266 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |      3,249.39 ns |     14.501 ns |     13.564 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,150.28 ns |      6.018 ns |      5.629 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,296.10 ns |      4.995 ns |      4.672 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,550.84 ns |      2.749 ns |      2.572 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |      3,463.09 ns |      2.816 ns |      2.634 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |      8,567.49 ns |     45.278 ns |     42.353 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |      9,694.90 ns |     55.205 ns |     51.639 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     11,513.57 ns |     45.604 ns |     38.082 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |     25,963.54 ns |     51.789 ns |     48.444 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     68,268.89 ns |    434.876 ns |    406.783 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     77,748.38 ns |    369.975 ns |    308.946 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     92,200.90 ns |    152.135 ns |    142.307 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 64KB         |    208,702.85 ns |    318.783 ns |    298.190 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    136,457.95 ns |    538.135 ns |    503.372 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    155,764.58 ns |    724.329 ns |    677.538 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    184,065.34 ns |    310.839 ns |    290.759 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        |    417,357.85 ns |    349.124 ns |    326.571 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,039,724.93 ns |  5,181.562 ns |  4,846.836 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,186,631.01 ns |  6,663.059 ns |  6,232.630 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,405,247.78 ns |  2,064.694 ns |  1,931.317 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1MB          |  3,184,769.57 ns |  3,013.682 ns |  2,819.000 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 10,431,117.45 ns | 47,651.203 ns | 44,572.965 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 11,892,796.71 ns | 58,979.279 ns | 55,169.254 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 14,040,184.10 ns | 19,025.256 ns | 16,865.394 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 10MB         | 31,841,950.72 ns | 33,673.020 ns | 28,118.496 ns |         - |