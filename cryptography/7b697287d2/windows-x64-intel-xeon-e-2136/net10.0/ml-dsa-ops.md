| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives                        | 302.01 μs |  5.864 μs |  6.517 μs |   92996 B |
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 304.34 μs |  3.781 μs |  3.536 μs |   92509 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 371.57 μs |  6.959 μs |  7.446 μs |  105796 B |
| Sign · ML-DSA-44 · OS                                 | 421.98 μs |  7.617 μs | 10.678 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives                        | 475.15 μs |  7.624 μs |  7.488 μs |  138568 B |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 480.46 μs |  9.208 μs | 10.962 μs |  139024 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 624.95 μs | 10.548 μs |  9.867 μs |  170271 B |
| Sign · ML-DSA-65 · OS                                 | 664.36 μs | 12.836 μs | 14.267 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 590.18 μs | 11.476 μs | 11.785 μs |  200281 B |
| Sign · ML-DSA-87 · CryptoHives                        | 591.11 μs |  9.914 μs |  9.273 μs |  199062 B |
| Sign · ML-DSA-87 · BouncyCastle                       | 725.33 μs | 10.116 μs |  8.967 μs |  241765 B |
| Sign · ML-DSA-87 · OS                                 | 725.51 μs | 13.651 μs | 14.018 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 289.65 μs |  3.195 μs |  2.833 μs |   92870 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 293.62 μs |  5.371 μs |  5.024 μs |   93253 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 382.44 μs |  5.804 μs |  5.429 μs |  106531 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 416.31 μs |  8.197 μs |  8.050 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 470.56 μs |  3.422 μs |  3.033 μs |  139161 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 474.05 μs |  7.303 μs |  6.831 μs |  139863 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 640.29 μs | 12.668 μs | 17.758 μs |  170531 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 667.05 μs | 13.278 μs | 15.291 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 582.98 μs |  6.932 μs |  5.788 μs |  199708 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 590.35 μs | 10.566 μs |  9.883 μs |  199387 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 722.06 μs | 13.886 μs | 14.858 μs |         - |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 735.34 μs | 13.806 μs | 12.914 μs |  244400 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  55.52 μs |  0.091 μs |  0.085 μs |         - |
| Verify · ML-DSA-44 · CryptoHives                      |  85.73 μs |  0.176 μs |  0.147 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  85.95 μs |  0.380 μs |  0.337 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     |  96.61 μs |  0.212 μs |  0.198 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               |  75.99 μs |  0.153 μs |  0.135 μs |         - |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 139.27 μs |  0.436 μs |  0.408 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives                      | 139.68 μs |  0.253 μs |  0.224 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 156.36 μs |  0.427 μs |  0.400 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               | 106.79 μs |  0.128 μs |  0.114 μs |         - |
| Verify · ML-DSA-87 · CryptoHives                      | 230.12 μs |  0.415 μs |  0.368 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 230.22 μs |  0.313 μs |  0.261 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 258.39 μs |  0.820 μs |  0.767 μs |  158544 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  54.16 μs |  0.714 μs |  0.668 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  83.77 μs |  0.121 μs |  0.107 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  83.78 μs |  0.194 μs |  0.181 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  97.18 μs |  0.238 μs |  0.223 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  75.15 μs |  1.309 μs |  1.225 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 141.17 μs |  2.412 μs |  2.256 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 141.43 μs |  2.485 μs |  2.324 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 163.07 μs |  2.909 μs |  2.721 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    | 107.38 μs |  1.516 μs |  1.418 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 234.95 μs |  3.494 μs |  3.268 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 235.45 μs |  3.074 μs |  2.875 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 269.66 μs |  4.125 μs |  3.858 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  57.43 μs |  0.743 μs |  0.695 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  88.10 μs |  1.528 μs |  1.430 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  88.20 μs |  1.498 μs |  1.401 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  99.40 μs |  1.905 μs |  1.871 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     |  76.13 μs |  0.111 μs |  0.104 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 142.17 μs |  2.741 μs |  2.815 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 144.72 μs |  0.962 μs |  0.900 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 159.22 μs |  0.177 μs |  0.157 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     | 110.68 μs |  1.375 μs |  1.219 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 237.77 μs |  3.210 μs |  3.003 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 237.97 μs |  4.156 μs |  3.888 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 267.72 μs |  4.072 μs |  3.809 μs |  158544 B |