| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 278.65 μs |  5.363 μs |  5.508 μs |   92617 B |
| Sign · ML-DSA-44 · CryptoHives                        | 279.85 μs |  5.261 μs |  4.921 μs |   92682 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 301.80 μs |  5.962 μs | 10.442 μs |  106629 B |
| Sign · ML-DSA-44 · OS                                 | 360.70 μs |  7.055 μs |  7.245 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives                        | 455.21 μs |  8.886 μs |  8.727 μs |  139324 B |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 458.06 μs |  6.411 μs |  5.997 μs |  138278 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 485.66 μs |  7.189 μs |  6.725 μs |  169711 B |
| Sign · ML-DSA-65 · OS                                 | 578.74 μs | 10.139 μs |  8.988 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives                        | 556.17 μs | 10.677 μs | 13.883 μs |  200308 B |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 560.76 μs | 11.025 μs | 16.160 μs |  200004 B |
| Sign · ML-DSA-87 · BouncyCastle                       | 604.13 μs |  9.971 μs |  9.327 μs |  238621 B |
| Sign · ML-DSA-87 · OS                                 | 637.63 μs |  9.543 μs |  8.460 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 278.63 μs |  4.261 μs |  3.985 μs |   93592 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 278.77 μs |  4.473 μs |  4.184 μs |   92727 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 298.85 μs |  5.683 μs |  5.316 μs |  106345 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 356.02 μs |  6.931 μs |  7.982 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 455.33 μs |  5.562 μs |  5.203 μs |  139816 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 457.30 μs |  9.120 μs |  8.957 μs |  139016 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 486.16 μs |  9.476 μs | 10.139 μs |  170686 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 574.42 μs | 11.052 μs | 13.573 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 553.63 μs | 10.979 μs | 10.270 μs |  200423 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 558.76 μs | 10.754 μs | 12.802 μs |  200301 B |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 601.75 μs | 11.383 μs | 11.180 μs |  241463 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 627.95 μs | 12.273 μs | 15.959 μs |         - |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  45.03 μs |  0.064 μs |  0.060 μs |         - |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  70.32 μs |  0.243 μs |  0.227 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives                      |  71.63 μs |  0.847 μs |  0.793 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     |  75.05 μs |  0.149 μs |  0.140 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               |  62.74 μs |  0.106 μs |  0.099 μs |         - |
| Verify · ML-DSA-65 · CryptoHives                      | 112.63 μs |  0.316 μs |  0.295 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 112.66 μs |  0.163 μs |  0.153 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 121.70 μs |  0.117 μs |  0.110 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               |  89.85 μs |  0.164 μs |  0.153 μs |         - |
| Verify · ML-DSA-87 · CryptoHives                      | 182.19 μs |  0.339 μs |  0.317 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 182.63 μs |  0.479 μs |  0.448 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 201.27 μs |  0.457 μs |  0.405 μs |  158544 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  43.16 μs |  0.081 μs |  0.072 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  69.02 μs |  0.167 μs |  0.156 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  69.16 μs |  0.140 μs |  0.124 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  75.17 μs |  0.202 μs |  0.189 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  60.99 μs |  0.076 μs |  0.068 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 111.01 μs |  0.260 μs |  0.243 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 111.09 μs |  0.153 μs |  0.135 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 121.53 μs |  0.156 μs |  0.146 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    |  87.95 μs |  0.142 μs |  0.126 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 181.19 μs |  0.455 μs |  0.426 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 181.74 μs |  0.524 μs |  0.490 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 200.80 μs |  0.304 μs |  0.284 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  45.06 μs |  0.096 μs |  0.080 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  70.38 μs |  0.286 μs |  0.268 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  70.65 μs |  0.350 μs |  0.273 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  75.05 μs |  0.253 μs |  0.237 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     |  62.82 μs |  0.204 μs |  0.191 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 112.39 μs |  0.156 μs |  0.145 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 112.52 μs |  0.222 μs |  0.185 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 121.33 μs |  0.175 μs |  0.155 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     |  89.66 μs |  0.127 μs |  0.119 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 182.33 μs |  0.531 μs |  0.497 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 182.42 μs |  0.320 μs |  0.284 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 201.38 μs |  0.443 μs |  0.393 μs |  158544 B |