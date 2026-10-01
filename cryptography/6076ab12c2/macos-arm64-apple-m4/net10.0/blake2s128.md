| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         74.81 ns |      0.012 ns |      0.010 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         81.30 ns |      0.025 ns |      0.020 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        106.15 ns |      0.085 ns |      0.076 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 4B           |        217.99 ns |      0.918 ns |      0.858 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         74.19 ns |      0.219 ns |      0.205 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         79.46 ns |      0.033 ns |      0.029 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        105.71 ns |      0.105 ns |      0.093 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64B          |        218.25 ns |      0.614 ns |      0.574 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        142.13 ns |      0.042 ns |      0.038 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        159.81 ns |      0.038 ns |      0.030 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        196.57 ns |      0.111 ns |      0.098 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 65B          |        440.19 ns |      1.355 ns |      1.267 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        141.68 ns |      0.029 ns |      0.026 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        159.27 ns |      0.051 ns |      0.045 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        197.13 ns |      0.134 ns |      0.125 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |        439.94 ns |      1.537 ns |      1.438 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        212.32 ns |      0.467 ns |      0.414 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        238.89 ns |      0.066 ns |      0.059 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        286.37 ns |      0.237 ns |      0.222 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 129B         |        663.02 ns |      2.257 ns |      2.000 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,113.00 ns |      2.491 ns |      2.208 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,270.00 ns |      2.917 ns |      2.586 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,477.66 ns |      3.290 ns |      3.077 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |      3,556.33 ns |     16.120 ns |     15.078 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,182.36 ns |      2.437 ns |      2.160 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,350.04 ns |      3.575 ns |      3.169 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,571.36 ns |      4.096 ns |      3.631 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |      3,782.18 ns |     17.836 ns |     16.684 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |      8,827.43 ns |     11.419 ns |      9.536 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     10,146.19 ns |     12.142 ns |     10.139 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     11,696.25 ns |     31.455 ns |     27.884 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |     28,451.24 ns |     92.913 ns |     82.365 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     70,578.57 ns |    173.315 ns |    153.639 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     81,269.10 ns |    166.916 ns |    147.967 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     93,420.84 ns |    221.222 ns |    196.108 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64KB         |    227,894.51 ns |    906.608 ns |    848.041 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    140,931.94 ns |    293.546 ns |    274.583 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    162,526.02 ns |    494.173 ns |    438.072 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    186,834.08 ns |    490.360 ns |    434.691 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        |    456,083.77 ns |  2,057.307 ns |  1,924.406 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,075,365.66 ns |  2,799.583 ns |  2,481.757 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,239,133.41 ns |  3,163.131 ns |  2,958.794 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,425,350.13 ns |  3,360.402 ns |  3,143.322 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1MB          |  3,486,049.20 ns | 16,231.321 ns | 14,388.644 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 10,751,258.37 ns | 29,659.674 ns | 26,292.528 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 12,403,280.21 ns | 35,394.128 ns | 33,107.690 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 14,264,187.33 ns | 37,813.638 ns | 35,370.900 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 10MB         | 34,830,907.74 ns | 97,567.165 ns | 86,490.750 ns |         - |