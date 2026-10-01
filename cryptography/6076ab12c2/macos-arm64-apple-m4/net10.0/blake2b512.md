| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Median           | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|-----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |         92.32 ns |      0.375 ns |      0.351 ns |         92.33 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |         96.03 ns |      0.255 ns |      0.238 ns |         96.02 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        125.21 ns |      0.494 ns |      0.462 ns |        125.12 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 4B           |        159.10 ns |      0.457 ns |      0.428 ns |        159.17 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        727.36 ns |      3.388 ns |      3.169 ns |        726.96 ns |     1096 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |         91.77 ns |      0.315 ns |      0.279 ns |         91.76 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |         95.75 ns |      0.340 ns |      0.302 ns |         95.81 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        125.86 ns |      0.421 ns |      0.394 ns |        125.82 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64B          |        159.44 ns |      0.548 ns |      0.512 ns |        159.39 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        699.20 ns |      2.392 ns |      2.238 ns |        699.09 ns |     1152 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |         92.39 ns |      0.362 ns |      0.338 ns |         92.34 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |         95.86 ns |      0.368 ns |      0.344 ns |         95.92 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        126.18 ns |      0.519 ns |      0.460 ns |        126.30 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 65B          |        158.85 ns |      0.505 ns |      0.473 ns |        158.77 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        700.00 ns |      2.938 ns |      2.748 ns |        699.72 ns |     1160 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |         91.35 ns |      0.411 ns |      0.384 ns |         91.28 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |         92.88 ns |      0.366 ns |      0.342 ns |         92.95 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        126.94 ns |      0.357 ns |      0.317 ns |        127.01 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |        159.20 ns |      0.533 ns |      0.472 ns |        159.27 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        671.28 ns |      3.691 ns |      3.272 ns |        671.59 ns |     1216 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        170.75 ns |      0.660 ns |      0.618 ns |        170.92 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        187.71 ns |      0.676 ns |      0.633 ns |        187.58 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        231.49 ns |      0.727 ns |      0.644 ns |        231.54 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 129B         |        322.12 ns |      0.791 ns |      0.740 ns |        322.25 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,255.01 ns |      5.692 ns |      5.324 ns |      1,253.27 ns |     1224 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        656.41 ns |      1.877 ns |      1.664 ns |        656.00 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |        732.17 ns |      3.352 ns |      2.972 ns |        732.11 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        875.22 ns |      2.923 ns |      2.734 ns |        875.43 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |      1,306.64 ns |      3.983 ns |      3.726 ns |      1,306.67 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      4,255.55 ns |     27.131 ns |     25.378 ns |      4,258.52 ns |     2112 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        736.31 ns |      0.910 ns |      0.806 ns |        736.25 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |        828.01 ns |      2.566 ns |      2.400 ns |        828.35 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        975.06 ns |      0.734 ns |      0.651 ns |        975.26 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |      1,452.17 ns |      0.598 ns |      0.560 ns |      1,452.19 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,809.34 ns |     22.801 ns |     21.328 ns |      4,802.37 ns |     2120 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,120.22 ns |     16.332 ns |     15.277 ns |      5,118.25 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      5,798.75 ns |     24.744 ns |     23.146 ns |      5,802.67 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,797.69 ns |      6.023 ns |      5.634 ns |      6,800.13 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |     10,348.11 ns |      3.314 ns |      2.938 ns |     10,347.18 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     32,626.64 ns |    141.552 ns |    125.482 ns |     32,574.76 ns |     9280 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     40,883.29 ns |    185.646 ns |    164.570 ns |     40,977.10 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     46,357.60 ns |     90.320 ns |     80.067 ns |     46,371.68 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     54,226.77 ns |     22.628 ns |     21.166 ns |     54,230.77 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64KB         |     82,843.48 ns |     28.351 ns |     26.519 ns |     82,835.33 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    259,025.07 ns |  1,172.720 ns |  1,096.963 ns |    258,412.48 ns |    66624 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     81,895.48 ns |    394.651 ns |    369.156 ns |     81,969.95 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |     92,685.07 ns |    338.011 ns |    316.176 ns |     92,700.12 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    108,479.87 ns |     67.059 ns |     59.446 ns |    108,486.24 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        |    165,761.99 ns |     42.171 ns |     39.447 ns |    165,777.42 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    526,170.78 ns |  2,247.166 ns |  2,102.000 ns |    525,263.75 ns |   132188 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    638,970.43 ns |    363.011 ns |    339.561 ns |    639,053.10 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |    706,546.15 ns |  3,186.542 ns |  2,980.694 ns |    705,033.12 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    828,250.23 ns |    753.544 ns |    704.865 ns |    828,365.84 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1MB          |  1,262,650.58 ns |  1,010.211 ns |    843.572 ns |  1,262,435.79 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  4,006,808.54 ns | 76,906.301 ns | 85,481.149 ns |  4,066,270.19 ns |  1002727 B |
|                                                   |              |                  |               |               |                  |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,403,278.49 ns |  3,352.725 ns |  3,136.141 ns |  6,402,449.87 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         |  7,328,915.60 ns |  2,467.064 ns |  2,186.988 ns |  7,329,269.85 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  8,416,612.91 ns |  5,329.174 ns |  4,724.174 ns |  8,417,049.16 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 10MB         | 13,692,394.67 ns | 74,754.543 ns | 69,925.446 ns | 13,704,568.38 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 42,315,182.55 ns | 85,614.414 ns | 75,894.948 ns | 42,321,920.17 ns | 10001252 B |