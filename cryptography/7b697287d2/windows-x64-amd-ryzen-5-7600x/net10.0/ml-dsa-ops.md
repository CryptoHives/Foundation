| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 258.92 μs |  4.003 μs |  3.744 μs |   92789 B |
| Sign · ML-DSA-44 · CryptoHives                        | 258.97 μs |  4.659 μs |  4.358 μs |   92488 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 292.24 μs |  2.999 μs |  2.806 μs |  106260 B |
| Sign · ML-DSA-44 · OS                                 | 354.84 μs |  6.674 μs |  6.854 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 423.28 μs |  6.900 μs |  6.454 μs |  139539 B |
| Sign · ML-DSA-65 · CryptoHives                        | 428.99 μs |  5.952 μs |  5.567 μs |  139469 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 482.25 μs |  6.277 μs |  5.872 μs |  170965 B |
| Sign · ML-DSA-65 · OS                                 | 567.87 μs | 10.955 μs | 12.616 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 516.01 μs | 10.282 μs | 10.559 μs |  199782 B |
| Sign · ML-DSA-87 · CryptoHives                        | 521.14 μs |  7.072 μs |  6.615 μs |  201244 B |
| Sign · ML-DSA-87 · BouncyCastle                       | 596.32 μs | 11.316 μs | 11.114 μs |  241917 B |
| Sign · ML-DSA-87 · OS                                 | 620.45 μs | 12.252 μs | 17.571 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 256.67 μs |  3.550 μs |  3.321 μs |   93012 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 257.88 μs |  3.484 μs |  3.259 μs |   93255 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 293.09 μs |  3.819 μs |  3.385 μs |  106516 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 353.21 μs |  6.062 μs |  5.671 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 422.12 μs |  8.310 μs |  7.773 μs |  139751 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 424.05 μs |  8.354 μs |  8.205 μs |  138850 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 479.38 μs |  6.132 μs |  5.436 μs |  171132 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 570.01 μs | 11.054 μs | 15.130 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 519.53 μs | 10.140 μs | 10.850 μs |  201126 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 521.26 μs |  9.958 μs |  9.780 μs |  199636 B |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 587.93 μs | 11.028 μs | 10.315 μs |  242198 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 621.82 μs | 11.979 μs | 13.314 μs |         - |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  44.99 μs |  0.066 μs |  0.058 μs |         - |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  68.02 μs |  0.189 μs |  0.177 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives                      |  68.29 μs |  0.130 μs |  0.122 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     |  74.92 μs |  0.239 μs |  0.224 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               |  62.84 μs |  0.271 μs |  0.253 μs |         - |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 109.02 μs |  0.132 μs |  0.110 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives                      | 109.29 μs |  0.273 μs |  0.242 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 121.39 μs |  0.172 μs |  0.144 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               |  89.69 μs |  0.222 μs |  0.197 μs |         - |
| Verify · ML-DSA-87 · CryptoHives                      | 178.34 μs |  0.446 μs |  0.348 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 178.37 μs |  0.368 μs |  0.345 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 200.86 μs |  0.368 μs |  0.326 μs |  158544 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  43.07 μs |  0.051 μs |  0.046 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  66.62 μs |  0.128 μs |  0.107 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  66.72 μs |  0.152 μs |  0.135 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  75.15 μs |  0.238 μs |  0.223 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  60.88 μs |  0.085 μs |  0.075 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 107.80 μs |  0.250 μs |  0.234 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 107.95 μs |  0.237 μs |  0.222 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 121.14 μs |  0.246 μs |  0.230 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    |  87.77 μs |  0.171 μs |  0.152 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 177.15 μs |  0.478 μs |  0.424 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 177.20 μs |  0.454 μs |  0.403 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 200.74 μs |  0.565 μs |  0.528 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  45.02 μs |  0.163 μs |  0.136 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  68.15 μs |  0.252 μs |  0.235 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  68.17 μs |  0.283 μs |  0.265 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  74.91 μs |  0.211 μs |  0.187 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     |  62.83 μs |  0.085 μs |  0.080 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 108.78 μs |  0.200 μs |  0.187 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 109.18 μs |  0.214 μs |  0.200 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 121.34 μs |  0.194 μs |  0.172 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     |  89.65 μs |  0.121 μs |  0.114 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 178.32 μs |  0.439 μs |  0.389 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 178.41 μs |  0.460 μs |  0.430 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 200.42 μs |  0.450 μs |  0.421 μs |  158544 B |