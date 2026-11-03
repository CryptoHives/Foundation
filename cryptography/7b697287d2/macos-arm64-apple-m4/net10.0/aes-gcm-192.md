| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|--------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      83.66 ns |   0.333 ns |   0.312 ns |      83.58 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     359.66 ns |   1.041 ns |   0.974 ns |     359.79 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     540.09 ns |   1.634 ns |   1.529 ns |     540.17 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,832.37 ns |   6.787 ns |   6.017 ns |   1,832.98 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.98 ns |   0.148 ns |   0.139 ns |      52.97 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     323.86 ns |   0.413 ns |   0.386 ns |     323.72 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     463.54 ns |   0.573 ns |   0.508 ns |     463.55 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,680.92 ns |   6.957 ns |   6.167 ns |   1,680.21 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      92.17 ns |   0.398 ns |   0.372 ns |      92.12 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     648.30 ns |   2.183 ns |   2.042 ns |     648.30 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     759.38 ns |   1.069 ns |   1.000 ns |     759.21 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,844.75 ns |  10.527 ns |   9.847 ns |   1,843.85 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      60.22 ns |   0.347 ns |   0.325 ns |      60.17 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     606.19 ns |   0.748 ns |   0.700 ns |     605.95 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     696.81 ns |   0.491 ns |   0.410 ns |     696.86 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,681.03 ns |  10.785 ns |  10.088 ns |   1,681.72 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      89.00 ns |   0.185 ns |   0.173 ns |      88.95 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     934.48 ns |   2.315 ns |   2.166 ns |     934.08 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     983.30 ns |   0.673 ns |   0.630 ns |     983.34 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,864.28 ns |  12.142 ns |  11.357 ns |   1,863.92 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      61.39 ns |   0.379 ns |   0.354 ns |      61.39 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     909.94 ns |   1.812 ns |   1.695 ns |     910.15 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     937.81 ns |   0.378 ns |   0.295 ns |     937.89 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,714.70 ns |  33.143 ns |  31.002 ns |   1,702.58 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     111.85 ns |   0.357 ns |   0.334 ns |     111.90 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,129.87 ns |   1.327 ns |   1.177 ns |   1,129.67 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,132.58 ns |   2.746 ns |   2.569 ns |   1,132.52 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,871.52 ns |   7.917 ns |   7.019 ns |   1,871.34 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      83.47 ns |   0.443 ns |   0.414 ns |      83.48 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,069.07 ns |   2.423 ns |   2.267 ns |   1,069.03 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,088.58 ns |   0.435 ns |   0.363 ns |   1,088.62 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,680.79 ns |   8.394 ns |   7.852 ns |   1,681.06 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     121.30 ns |   0.459 ns |   0.429 ns |     121.14 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,549.82 ns |   0.694 ns |   0.649 ns |   1,549.79 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,740.37 ns |   7.667 ns |   7.172 ns |   1,739.39 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,876.10 ns |  12.669 ns |  11.850 ns |   1,873.52 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      87.42 ns |   0.239 ns |   0.223 ns |      87.42 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,547.02 ns |   0.675 ns |   0.563 ns |   1,546.96 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,668.17 ns |   2.487 ns |   2.204 ns |   1,668.10 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,714.95 ns |   6.905 ns |   6.459 ns |   1,715.17 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     300.17 ns |   1.138 ns |   1.065 ns |     299.84 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,007.04 ns |  10.315 ns |   9.649 ns |   2,006.05 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,899.30 ns |   2.170 ns |   1.812 ns |   4,899.83 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,012.84 ns |   5.645 ns |   5.280 ns |   6,013.04 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     267.52 ns |   1.608 ns |   1.504 ns |     267.77 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,861.87 ns |  11.914 ns |  11.144 ns |   1,860.75 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,215.53 ns |   7.521 ns |   6.667 ns |   5,215.12 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   5,847.18 ns |   2.020 ns |   1.577 ns |   5,847.20 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,254.09 ns | 106.802 ns | 314.909 ns |   2,097.54 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,878.92 ns |  11.988 ns |  10.627 ns |   2,879.15 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  35,899.12 ns |  21.803 ns |  20.394 ns |  35,902.05 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  46,625.31 ns | 180.380 ns | 168.727 ns |  46,681.38 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,967.58 ns |   4.930 ns |   3.849 ns |   1,966.60 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,777.68 ns |  17.930 ns |  16.772 ns |   2,771.76 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  38,483.92 ns |  14.191 ns |  13.274 ns |  38,488.55 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  45,429.72 ns |  27.748 ns |  24.598 ns |  45,432.34 ns |         - |
|                                                   |              |               |            |            |               |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,018.08 ns | 127.635 ns | 119.389 ns |  19,017.93 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  30,614.58 ns |  58.812 ns |  55.013 ns |  30,619.39 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 569,885.21 ns | 351.457 ns | 328.753 ns | 569,871.17 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 726,206.83 ns | 556.180 ns | 464.435 ns | 726,158.41 ns |         - |
|                                                   |              |               |            |            |               |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,125.90 ns | 195.319 ns | 182.702 ns |  20,189.04 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  30,583.27 ns | 131.870 ns | 123.351 ns |  30,553.74 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 615,541.21 ns | 181.428 ns | 160.831 ns | 615,526.59 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 724,346.49 ns | 500.890 ns | 418.266 ns | 724,345.05 ns |         - |