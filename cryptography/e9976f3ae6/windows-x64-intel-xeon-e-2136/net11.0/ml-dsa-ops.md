| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 394.03 μs |  5.340 μs |  4.995 μs |   93197 B |
| Sign · ML-DSA-44 · CryptoHives                        | 394.31 μs |  5.244 μs |  4.906 μs |   92827 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 462.86 μs |  7.772 μs |  7.270 μs |  106598 B |
| Sign · ML-DSA-44 · OS                                 | 569.40 μs | 11.210 μs | 17.118 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 633.74 μs | 12.013 μs | 11.237 μs |  139469 B |
| Sign · ML-DSA-65 · CryptoHives                        | 638.20 μs | 12.288 μs | 15.090 μs |  139759 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 789.50 μs | 14.027 μs | 12.434 μs |  170706 B |
| Sign · ML-DSA-65 · OS                                 | 900.47 μs | 17.143 μs | 19.742 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 781.31 μs | 15.401 μs | 16.479 μs |  199344 B |
| Sign · ML-DSA-87 · CryptoHives                        | 796.97 μs | 15.576 μs | 14.570 μs |  199981 B |
| Sign · ML-DSA-87 · OS                                 | 979.23 μs | 19.473 μs | 18.215 μs |         - |
| Sign · ML-DSA-87 · BouncyCastle                       | 981.04 μs | 17.591 μs | 16.455 μs |  242942 B |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 394.38 μs |  5.176 μs |  4.841 μs |   93268 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 397.10 μs |  3.894 μs |  3.040 μs |   93372 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 508.30 μs | 10.134 μs | 11.670 μs |  107500 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 563.88 μs | 11.145 μs | 14.491 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 627.93 μs | 12.046 μs | 16.081 μs |  138822 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 628.76 μs | 12.456 μs | 13.328 μs |  139215 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 783.40 μs | 14.709 μs | 12.283 μs |  169017 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 896.34 μs | 17.703 μs | 24.817 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 785.97 μs | 14.401 μs | 13.471 μs |  200916 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 787.51 μs |  9.623 μs |  9.001 μs |  201032 B |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 961.92 μs | 17.309 μs | 16.191 μs |  243500 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 972.23 μs | 18.867 μs | 27.059 μs |         - |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  75.50 μs |  0.581 μs |  0.515 μs |         - |
| Verify · ML-DSA-44 · CryptoHives                      | 117.55 μs |  0.537 μs |  0.502 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives-Stateless            | 117.76 μs |  0.538 μs |  0.503 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     | 127.77 μs |  0.612 μs |  0.543 μs |   56984 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               | 102.95 μs |  0.272 μs |  0.241 μs |         - |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 189.42 μs |  0.645 μs |  0.571 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives                      | 189.84 μs |  0.571 μs |  0.534 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 202.59 μs |  0.528 μs |  0.494 μs |   95032 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               | 145.37 μs |  0.854 μs |  0.799 μs |         - |
| Verify · ML-DSA-87 · CryptoHives                      | 312.04 μs |  0.846 μs |  0.750 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 312.20 μs |  0.937 μs |  0.877 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 338.46 μs |  0.732 μs |  0.649 μs |  158536 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  71.40 μs |  0.443 μs |  0.392 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           | 113.39 μs |  0.344 μs |  0.322 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless | 115.26 μs |  0.319 μs |  0.283 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          | 134.31 μs |  0.361 μs |  0.320 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  98.92 μs |  0.072 μs |  0.060 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 184.39 μs |  0.366 μs |  0.342 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 184.88 μs |  0.874 μs |  0.730 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 206.58 μs |  0.576 μs |  0.481 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    | 140.81 μs |  0.182 μs |  0.170 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 308.30 μs |  0.892 μs |  0.834 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 309.53 μs |  0.695 μs |  0.581 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 338.70 μs |  1.984 μs |  1.856 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  75.45 μs |  0.358 μs |  0.334 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives            | 115.53 μs |  0.362 μs |  0.339 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  | 118.00 μs |  0.574 μs |  0.537 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           | 132.99 μs |  0.441 μs |  0.391 μs |   56984 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     | 103.02 μs |  0.248 μs |  0.220 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 186.69 μs |  0.206 μs |  0.172 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 187.29 μs |  0.464 μs |  0.434 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 206.21 μs |  0.546 μs |  0.511 μs |   95032 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     | 144.98 μs |  0.545 μs |  0.509 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 308.96 μs |  0.849 μs |  0.794 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 309.06 μs |  0.625 μs |  0.522 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 335.08 μs |  0.731 μs |  0.648 μs |  158536 B |