| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         73.87 ns |      0.443 ns |      0.415 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         79.40 ns |      0.295 ns |      0.262 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        104.76 ns |      0.314 ns |      0.263 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 4B           |        202.11 ns |      0.483 ns |      0.452 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         73.60 ns |      0.231 ns |      0.216 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         77.26 ns |      0.252 ns |      0.236 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        105.33 ns |      0.317 ns |      0.297 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64B          |        202.10 ns |      0.520 ns |      0.486 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        140.53 ns |      0.491 ns |      0.459 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        155.71 ns |      0.722 ns |      0.676 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        194.70 ns |      0.454 ns |      0.425 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 65B          |        406.35 ns |      1.627 ns |      1.522 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        139.36 ns |      0.574 ns |      0.479 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        154.47 ns |      0.856 ns |      0.801 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        196.30 ns |      0.552 ns |      0.516 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |        406.29 ns |      0.864 ns |      0.766 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        208.28 ns |      0.523 ns |      0.490 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        232.11 ns |      0.740 ns |      0.692 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        284.65 ns |      1.132 ns |      1.059 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 129B         |        611.59 ns |      1.675 ns |      1.567 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,086.43 ns |      8.739 ns |      8.175 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,229.40 ns |      7.118 ns |      6.658 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,462.20 ns |      5.996 ns |      5.608 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |      3,269.09 ns |     12.158 ns |     11.373 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,154.53 ns |      5.841 ns |      5.464 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,304.67 ns |      6.644 ns |      6.215 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,554.39 ns |      4.882 ns |      4.566 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |      3,477.11 ns |      8.927 ns |      8.350 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |      8,615.90 ns |     53.550 ns |     50.091 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |      9,811.09 ns |     52.483 ns |     49.093 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     11,567.96 ns |     44.313 ns |     41.451 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |     26,192.01 ns |     73.323 ns |     68.586 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     68,690.29 ns |    408.939 ns |    382.522 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     78,344.35 ns |    394.683 ns |    369.187 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     92,413.85 ns |    227.209 ns |    212.531 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64KB         |    209,507.17 ns |    364.556 ns |    341.006 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    137,393.72 ns |    673.133 ns |    629.649 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    156,844.68 ns |    807.525 ns |    755.360 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    184,864.79 ns |    565.004 ns |    528.506 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        |    418,892.92 ns |  1,056.403 ns |    988.160 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,046,605.33 ns |  6,581.504 ns |  6,156.343 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,196,097.51 ns |  9,477.303 ns |  8,865.075 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,410,521.55 ns |  4,785.177 ns |  4,476.057 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1MB          |  3,194,863.63 ns |  6,755.931 ns |  5,988.956 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 10,473,119.96 ns | 49,559.447 ns | 46,357.937 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 11,991,551.88 ns | 41,800.535 ns | 39,100.246 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 14,126,214.88 ns | 38,266.788 ns | 35,794.777 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 10MB         | 31,961,581.25 ns | 80,018.564 ns | 74,849.414 ns |         - |