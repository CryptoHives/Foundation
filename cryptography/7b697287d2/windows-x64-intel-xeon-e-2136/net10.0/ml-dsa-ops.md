| Description                                           | Mean        | Error     | StdDev    | Allocated |
|------------------------------------------------------ |------------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives-Stateless              |   396.76 μs |  6.852 μs |  6.074 μs |   92697 B |
| Sign · ML-DSA-44 · CryptoHives                        |   399.47 μs |  4.323 μs |  4.043 μs |   92892 B |
| Sign · ML-DSA-44 · BouncyCastle                       |   513.50 μs | 10.060 μs | 11.182 μs |  107484 B |
| Sign · ML-DSA-44 · OS                                 |   585.29 μs | 11.512 μs | 16.510 μs |         - |
|                                                       |             |           |           |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              |   639.99 μs | 12.397 μs | 11.596 μs |  139895 B |
| Sign · ML-DSA-65 · CryptoHives                        |   644.42 μs | 12.816 μs | 13.713 μs |  139020 B |
| Sign · ML-DSA-65 · BouncyCastle                       |   798.61 μs | 11.638 μs | 10.886 μs |  170271 B |
| Sign · ML-DSA-65 · OS                                 |   902.49 μs | 17.667 μs | 19.637 μs |         - |
|                                                       |             |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              |   797.97 μs | 10.930 μs | 10.224 μs |  200430 B |
| Sign · ML-DSA-87 · CryptoHives                        |   803.42 μs | 15.742 μs | 14.725 μs |  200951 B |
| Sign · ML-DSA-87 · OS                                 |   979.74 μs | 19.460 μs | 32.513 μs |         - |
| Sign · ML-DSA-87 · BouncyCastle                       | 1,023.22 μs | 20.009 μs | 20.548 μs |  241599 B |
|                                                       |             |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             |   390.82 μs |  6.304 μs |  5.588 μs |   92912 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   |   393.89 μs |  4.785 μs |  4.476 μs |   93171 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            |   524.80 μs |  6.746 μs |  6.310 μs |  107364 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      |   568.79 μs | 11.224 μs | 13.361 μs |         - |
|                                                       |             |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             |   639.01 μs | 12.758 μs | 12.530 μs |  139351 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   |   647.65 μs | 11.677 μs | 10.923 μs |  140366 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            |   794.71 μs | 13.459 μs | 12.589 μs |  172086 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      |   890.13 μs | 17.221 μs | 17.685 μs |         - |
|                                                       |             |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             |   794.18 μs | 14.808 μs | 13.851 μs |  200877 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   |   798.60 μs | 13.567 μs | 12.691 μs |  200805 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      |   972.73 μs | 18.851 μs | 28.215 μs |         - |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 1,057.40 μs | 20.691 μs | 29.006 μs |  241810 B |
|                                                       |             |           |           |           |
| Verify · ML-DSA-44 · OS                               |    75.25 μs |  0.227 μs |  0.201 μs |         - |
| Verify · ML-DSA-44 · CryptoHives                      |   116.14 μs |  0.348 μs |  0.308 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |   116.18 μs |  0.413 μs |  0.366 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     |   131.25 μs |  0.489 μs |  0.457 μs |   56992 B |
|                                                       |             |           |           |           |
| Verify · ML-DSA-65 · OS                               |   103.41 μs |  0.348 μs |  0.309 μs |         - |
| Verify · ML-DSA-65 · CryptoHives                      |   188.12 μs |  0.322 μs |  0.301 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives-Stateless            |   188.42 μs |  0.278 μs |  0.260 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     |   212.62 μs |  0.210 μs |  0.196 μs |   95040 B |
|                                                       |             |           |           |           |
| Verify · ML-DSA-87 · OS                               |   144.69 μs |  0.214 μs |  0.201 μs |         - |
| Verify · ML-DSA-87 · CryptoHives-Stateless            |   311.87 μs |  0.349 μs |  0.291 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives                      |   312.03 μs |  0.588 μs |  0.550 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     |   356.69 μs |  0.565 μs |  0.529 μs |  158544 B |
|                                                       |             |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |    72.24 μs |  1.100 μs |  1.029 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |   113.56 μs |  0.140 μs |  0.124 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |   113.56 μs |  0.237 μs |  0.210 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |   133.63 μs |  0.187 μs |  0.175 μs |   57416 B |
|                                                       |             |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |    99.66 μs |  0.618 μs |  0.578 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless |   186.01 μs |  0.288 μs |  0.269 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           |   186.36 μs |  0.532 μs |  0.472 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          |   214.12 μs |  0.261 μs |  0.232 μs |   95464 B |
|                                                       |             |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    |   143.34 μs |  0.338 μs |  0.282 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           |   309.44 μs |  0.598 μs |  0.560 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless |   309.84 μs |  0.569 μs |  0.532 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          |   356.76 μs |  0.750 μs |  0.701 μs |  158968 B |
|                                                       |             |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |    76.35 μs |  1.187 μs |  1.111 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |   116.37 μs |  0.246 μs |  0.230 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |   116.43 μs |  0.243 μs |  0.228 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |   131.12 μs |  0.263 μs |  0.233 μs |   56992 B |
|                                                       |             |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     |   103.49 μs |  0.858 μs |  0.803 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  |   188.29 μs |  0.162 μs |  0.144 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives            |   188.89 μs |  0.229 μs |  0.214 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           |   214.59 μs |  0.279 μs |  0.247 μs |   95040 B |
|                                                       |             |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     |   144.97 μs |  0.399 μs |  0.373 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  |   311.90 μs |  0.332 μs |  0.294 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives            |   312.27 μs |  0.696 μs |  0.617 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           |   355.31 μs |  0.556 μs |  0.520 μs |  158544 B |