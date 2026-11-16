| Description                                           | Mean       | Error     | StdDev    | Median     | Allocated  |
|------------------------------------------------------ |-----------:|----------:|----------:|-----------:|-----------:|
| Sign · SLH-DSA-SHA2-128f · BouncyCastle               |  28.051 ms | 0.0639 ms | 0.0566 ms |  28.079 ms |  795.34 KB |
| Sign · SLH-DSA-SHA2-128f · CryptoHives                |  38.621 ms | 0.0760 ms | 0.0674 ms |  38.624 ms |  404.77 KB |
|                                                       |            |           |           |            |            |
| Sign · SLH-DSA-SHAKE-128f · CryptoHives               |  26.824 ms | 0.0382 ms | 0.0339 ms |  26.825 ms |  404.55 KB |
| Sign · SLH-DSA-SHAKE-128f · BouncyCastle              |  41.605 ms | 0.1124 ms | 0.1051 ms |  41.565 ms |  791.79 KB |
|                                                       |            |           |           |            |            |
| Sign · SLH-DSA-SHA2-192f · BouncyCastle               |  45.836 ms | 0.1049 ms | 0.0876 ms |  45.844 ms | 1667.02 KB |
| Sign · SLH-DSA-SHA2-192f · CryptoHives                |  62.776 ms | 0.0725 ms | 0.0566 ms |  62.778 ms | 1485.48 KB |
|                                                       |            |           |           |            |            |
| Sign · SLH-DSA-SHAKE-192f · CryptoHives               |  43.410 ms | 0.0670 ms | 0.0559 ms |  43.402 ms | 1484.91 KB |
| Sign · SLH-DSA-SHAKE-192f · BouncyCastle              |  67.421 ms | 0.1138 ms | 0.1065 ms |  67.433 ms | 1660.57 KB |
|                                                       |            |           |           |            |            |
| Sign · SLH-DSA-SHA2-256f · BouncyCastle               |  95.645 ms | 0.1976 ms | 0.1751 ms |  95.607 ms | 3747.81 KB |
| Sign · SLH-DSA-SHA2-256f · CryptoHives                | 128.242 ms | 0.3043 ms | 0.2698 ms | 128.250 ms |  3547.2 KB |
|                                                       |            |           |           |            |            |
| Sign · SLH-DSA-SHAKE-256f · CryptoHives               |  89.101 ms | 0.2611 ms | 0.2315 ms |  89.157 ms | 3546.63 KB |
| Sign · SLH-DSA-SHAKE-256f · BouncyCastle              | 139.706 ms | 0.3642 ms | 0.3228 ms | 139.674 ms | 3741.31 KB |
|                                                       |            |           |           |            |            |
| Sign (pre-hash) · SLH-DSA-SHA2-128f · BouncyCastle    |  28.025 ms | 0.0939 ms | 0.0832 ms |  28.009 ms |  795.34 KB |
| Sign (pre-hash) · SLH-DSA-SHA2-128f · CryptoHives     |  38.350 ms | 0.0378 ms | 0.0295 ms |  38.351 ms |  405.09 KB |
|                                                       |            |           |           |            |            |
| Sign (pre-hash) · SLH-DSA-SHAKE-128f · CryptoHives    |  26.958 ms | 0.1813 ms | 0.1607 ms |  26.875 ms |  404.88 KB |
| Sign (pre-hash) · SLH-DSA-SHAKE-128f · BouncyCastle   |  41.563 ms | 0.0871 ms | 0.0772 ms |  41.526 ms |  791.79 KB |
|                                                       |            |           |           |            |            |
| Sign (pre-hash) · SLH-DSA-SHA2-192f · BouncyCastle    |  45.829 ms | 0.1405 ms | 0.1314 ms |  45.780 ms | 1667.02 KB |
| Sign (pre-hash) · SLH-DSA-SHA2-192f · CryptoHives     |  64.635 ms | 0.0809 ms | 0.0717 ms |  64.636 ms | 1485.81 KB |
|                                                       |            |           |           |            |            |
| Sign (pre-hash) · SLH-DSA-SHAKE-192f · CryptoHives    |  43.493 ms | 0.1171 ms | 0.1038 ms |  43.472 ms | 1485.25 KB |
| Sign (pre-hash) · SLH-DSA-SHAKE-192f · BouncyCastle   |  67.054 ms | 0.1821 ms | 0.1615 ms |  67.004 ms | 1660.57 KB |
|                                                       |            |           |           |            |            |
| Sign (pre-hash) · SLH-DSA-SHA2-256f · BouncyCastle    |  95.567 ms | 0.2781 ms | 0.2602 ms |  95.498 ms | 3747.81 KB |
| Sign (pre-hash) · SLH-DSA-SHA2-256f · CryptoHives     | 128.667 ms | 0.3835 ms | 0.3587 ms | 128.548 ms | 3547.53 KB |
|                                                       |            |           |           |            |            |
| Sign (pre-hash) · SLH-DSA-SHAKE-256f · CryptoHives    |  89.161 ms | 0.2068 ms | 0.1833 ms |  89.148 ms | 3546.96 KB |
| Sign (pre-hash) · SLH-DSA-SHAKE-256f · BouncyCastle   | 139.409 ms | 0.2915 ms | 0.2276 ms | 139.411 ms | 3741.31 KB |
|                                                       |            |           |           |            |            |
| Verify · SLH-DSA-SHA2-128f · BouncyCastle             |   1.666 ms | 0.0031 ms | 0.0027 ms |   1.666 ms |   21.24 KB |
| Verify · SLH-DSA-SHA2-128f · CryptoHives              |   2.334 ms | 0.0028 ms | 0.0023 ms |   2.335 ms |   16.99 KB |
|                                                       |            |           |           |            |            |
| Verify · SLH-DSA-SHAKE-128f · CryptoHives             |   1.544 ms | 0.0037 ms | 0.0033 ms |   1.544 ms |   17.19 KB |
| Verify · SLH-DSA-SHAKE-128f · BouncyCastle            |   2.360 ms | 0.0065 ms | 0.0058 ms |   2.359 ms |   18.56 KB |
|                                                       |            |           |           |            |            |
| Verify · SLH-DSA-SHA2-192f · BouncyCastle             |   2.377 ms | 0.0058 ms | 0.0051 ms |   2.378 ms |   38.04 KB |
| Verify · SLH-DSA-SHA2-192f · CryptoHives              |   3.371 ms | 0.0058 ms | 0.0048 ms |   3.370 ms |   31.74 KB |
|                                                       |            |           |           |            |            |
| Verify · SLH-DSA-SHAKE-192f · CryptoHives             |   2.357 ms | 0.0053 ms | 0.0047 ms |   2.356 ms |   31.72 KB |
| Verify · SLH-DSA-SHAKE-192f · BouncyCastle            |   3.367 ms | 0.0059 ms | 0.0053 ms |   3.366 ms |   33.29 KB |
|                                                       |            |           |           |            |            |
| Verify · SLH-DSA-SHA2-256f · BouncyCastle             |   2.468 ms | 0.0048 ms | 0.0043 ms |   2.467 ms |   46.72 KB |
| Verify · SLH-DSA-SHA2-256f · CryptoHives              |   3.332 ms | 0.0070 ms | 0.0062 ms |   3.332 ms |   40.47 KB |
|                                                       |            |           |           |            |            |
| Verify · SLH-DSA-SHAKE-256f · CryptoHives             |   2.382 ms | 0.0056 ms | 0.0050 ms |   2.381 ms |   40.45 KB |
| Verify · SLH-DSA-SHAKE-256f · BouncyCastle            |   3.647 ms | 0.0197 ms | 0.0164 ms |   3.640 ms |   41.93 KB |
|                                                       |            |           |           |            |            |
| Verify (pre-hash) · SLH-DSA-SHA2-128f · BouncyCastle  |   1.649 ms | 0.0116 ms | 0.0103 ms |   1.645 ms |   21.24 KB |
| Verify (pre-hash) · SLH-DSA-SHA2-128f · CryptoHives   |   2.279 ms | 0.0053 ms | 0.0047 ms |   2.278 ms |   17.32 KB |
|                                                       |            |           |           |            |            |
| Verify (pre-hash) · SLH-DSA-SHAKE-128f · CryptoHives  |   1.626 ms | 0.0307 ms | 0.0753 ms |   1.593 ms |   17.52 KB |
| Verify (pre-hash) · SLH-DSA-SHAKE-128f · BouncyCastle |   2.403 ms | 0.0107 ms | 0.0100 ms |   2.399 ms |   18.56 KB |
|                                                       |            |           |           |            |            |
| Verify (pre-hash) · SLH-DSA-SHA2-192f · BouncyCastle  |   2.438 ms | 0.0183 ms | 0.0153 ms |   2.433 ms |   38.04 KB |
| Verify (pre-hash) · SLH-DSA-SHA2-192f · CryptoHives   |   3.497 ms | 0.0176 ms | 0.0165 ms |   3.499 ms |   32.07 KB |
|                                                       |            |           |           |            |            |
| Verify (pre-hash) · SLH-DSA-SHAKE-192f · CryptoHives  |   2.435 ms | 0.0482 ms | 0.0778 ms |   2.401 ms |   32.05 KB |
| Verify (pre-hash) · SLH-DSA-SHAKE-192f · BouncyCastle |   3.514 ms | 0.0224 ms | 0.0199 ms |   3.508 ms |   33.29 KB |
|                                                       |            |           |           |            |            |
| Verify (pre-hash) · SLH-DSA-SHA2-256f · BouncyCastle  |   2.389 ms | 0.0056 ms | 0.0047 ms |   2.389 ms |   46.72 KB |
| Verify (pre-hash) · SLH-DSA-SHA2-256f · CryptoHives   |   3.339 ms | 0.0099 ms | 0.0093 ms |   3.338 ms |    40.8 KB |
|                                                       |            |           |           |            |            |
| Verify (pre-hash) · SLH-DSA-SHAKE-256f · CryptoHives  |   2.313 ms | 0.0072 ms | 0.0064 ms |   2.313 ms |   40.78 KB |
| Verify (pre-hash) · SLH-DSA-SHAKE-256f · BouncyCastle |   3.645 ms | 0.0146 ms | 0.0130 ms |   3.642 ms |   41.93 KB |
|                                                       |            |           |           |            |            |
| Verify (invalid) · SLH-DSA-SHA2-128f · BouncyCastle   |   1.598 ms | 0.0025 ms | 0.0021 ms |   1.599 ms |   21.24 KB |
| Verify (invalid) · SLH-DSA-SHA2-128f · CryptoHives    |   2.344 ms | 0.0065 ms | 0.0058 ms |   2.343 ms |   16.99 KB |
|                                                       |            |           |           |            |            |
| Verify (invalid) · SLH-DSA-SHAKE-128f · CryptoHives   |   1.668 ms | 0.0046 ms | 0.0041 ms |   1.668 ms |   17.19 KB |
| Verify (invalid) · SLH-DSA-SHAKE-128f · BouncyCastle  |   2.313 ms | 0.0063 ms | 0.0059 ms |   2.313 ms |   18.56 KB |
|                                                       |            |           |           |            |            |
| Verify (invalid) · SLH-DSA-SHA2-192f · BouncyCastle   |   2.371 ms | 0.0116 ms | 0.0103 ms |   2.367 ms |   38.04 KB |
| Verify (invalid) · SLH-DSA-SHA2-192f · CryptoHives    |   3.374 ms | 0.0109 ms | 0.0091 ms |   3.373 ms |   31.74 KB |
|                                                       |            |           |           |            |            |
| Verify (invalid) · SLH-DSA-SHAKE-192f · CryptoHives   |   2.338 ms | 0.0054 ms | 0.0051 ms |   2.337 ms |   31.72 KB |
| Verify (invalid) · SLH-DSA-SHAKE-192f · BouncyCastle  |   3.364 ms | 0.0057 ms | 0.0051 ms |   3.364 ms |   33.29 KB |
|                                                       |            |           |           |            |            |
| Verify (invalid) · SLH-DSA-SHA2-256f · BouncyCastle   |   2.453 ms | 0.0057 ms | 0.0047 ms |   2.452 ms |   46.72 KB |
| Verify (invalid) · SLH-DSA-SHA2-256f · CryptoHives    |   3.431 ms | 0.0086 ms | 0.0080 ms |   3.429 ms |   40.47 KB |
|                                                       |            |           |           |            |            |
| Verify (invalid) · SLH-DSA-SHAKE-256f · CryptoHives   |   2.382 ms | 0.0094 ms | 0.0078 ms |   2.383 ms |   40.45 KB |
| Verify (invalid) · SLH-DSA-SHAKE-256f · BouncyCastle  |   3.575 ms | 0.0164 ms | 0.0146 ms |   3.575 ms |   41.93 KB |