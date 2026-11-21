| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 264.79 μs |  4.051 μs |  3.592 μs |   93417 B |
| Sign · ML-DSA-44 · CryptoHives                        | 267.08 μs |  5.184 μs |  6.920 μs |   92691 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 298.66 μs |  4.859 μs |  4.545 μs |  106290 B |
| Sign · ML-DSA-44 · OS                                 | 360.72 μs |  6.584 μs |  6.159 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives                        | 431.79 μs |  6.714 μs |  5.607 μs |  140187 B |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 436.18 μs |  7.383 μs |  6.906 μs |  139195 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 491.56 μs |  6.482 μs |  5.746 μs |  169462 B |
| Sign · ML-DSA-65 · OS                                 | 575.62 μs | 10.294 μs | 12.642 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 528.01 μs | 10.266 μs | 10.083 μs |  199145 B |
| Sign · ML-DSA-87 · CryptoHives                        | 530.15 μs |  9.950 μs | 10.218 μs |  199477 B |
| Sign · ML-DSA-87 · BouncyCastle                       | 610.88 μs | 11.181 μs | 10.458 μs |  241377 B |
| Sign · ML-DSA-87 · OS                                 | 634.58 μs | 12.568 μs | 21.341 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 262.10 μs |  3.851 μs |  3.414 μs |   92725 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 262.81 μs |  5.170 μs |  4.836 μs |   92966 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 301.17 μs |  4.553 μs |  4.259 μs |  106805 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 359.51 μs |  6.794 μs |  6.977 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 433.65 μs |  8.631 μs |  8.476 μs |  139870 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 433.91 μs |  8.580 μs |  8.811 μs |  139084 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 493.43 μs |  9.726 μs | 13.949 μs |  171360 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 581.65 μs | 10.305 μs | 11.867 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 530.80 μs |  9.717 μs |  8.614 μs |  199692 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 536.80 μs | 10.709 μs | 10.517 μs |  200860 B |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 611.11 μs | 12.117 μs | 14.424 μs |  244857 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 633.72 μs | 12.044 μs | 14.791 μs |         - |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  45.92 μs |  0.620 μs |  0.580 μs |         - |
| Verify · ML-DSA-44 · CryptoHives                      |  70.19 μs |  1.026 μs |  0.960 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  70.20 μs |  1.115 μs |  1.043 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     |  77.37 μs |  1.034 μs |  0.967 μs |   56984 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               |  64.41 μs |  0.788 μs |  0.737 μs |         - |
| Verify · ML-DSA-65 · CryptoHives                      | 112.44 μs |  1.160 μs |  1.085 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 113.55 μs |  1.411 μs |  1.251 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 125.66 μs |  1.878 μs |  1.757 μs |   95032 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               |  91.73 μs |  1.108 μs |  1.036 μs |         - |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 184.83 μs |  2.469 μs |  2.310 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives                      | 184.98 μs |  2.852 μs |  2.667 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 207.44 μs |  2.452 μs |  2.174 μs |  158536 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  44.30 μs |  0.871 μs |  0.815 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  68.58 μs |  0.746 μs |  0.698 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  68.73 μs |  1.048 μs |  0.980 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  77.27 μs |  0.944 μs |  0.883 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  62.20 μs |  0.543 μs |  0.508 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 111.08 μs |  1.231 μs |  1.151 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 111.09 μs |  1.570 μs |  1.469 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 125.61 μs |  1.178 μs |  1.044 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    |  89.98 μs |  1.367 μs |  1.279 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 182.38 μs |  2.597 μs |  2.429 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 182.65 μs |  2.295 μs |  2.035 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 207.00 μs |  2.104 μs |  1.969 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  46.03 μs |  0.549 μs |  0.513 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  70.36 μs |  1.195 μs |  1.118 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  70.43 μs |  1.199 μs |  1.122 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  77.77 μs |  1.141 μs |  1.011 μs |   56984 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     |  63.99 μs |  0.687 μs |  0.609 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 112.04 μs |  1.263 μs |  1.181 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 112.48 μs |  1.211 μs |  1.133 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 125.41 μs |  1.583 μs |  1.404 μs |   95032 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     |  90.36 μs |  0.311 μs |  0.276 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 182.85 μs |  1.805 μs |  1.600 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 183.81 μs |  1.593 μs |  1.490 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 207.33 μs |  2.296 μs |  2.147 μs |  158536 B |