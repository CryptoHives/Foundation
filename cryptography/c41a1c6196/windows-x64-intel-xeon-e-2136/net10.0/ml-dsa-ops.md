| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives                        | 399.13 μs |  6.596 μs |  5.847 μs |   93051 B |
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 399.92 μs |  4.400 μs |  3.901 μs |   92471 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 483.74 μs |  8.472 μs |  7.925 μs |  105302 B |
| Sign · ML-DSA-44 · OS                                 | 570.29 μs |  9.162 μs |  8.570 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives                        | 636.02 μs |  9.498 μs |  8.420 μs |  138748 B |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 639.22 μs | 12.670 μs | 16.024 μs |  139347 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 840.52 μs | 16.395 μs | 13.690 μs |  167223 B |
| Sign · ML-DSA-65 · OS                                 | 900.23 μs | 17.478 μs | 17.948 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 796.75 μs | 15.635 μs | 14.625 μs |  199688 B |
| Sign · ML-DSA-87 · CryptoHives                        | 799.98 μs | 15.148 μs | 17.445 μs |  200846 B |
| Sign · ML-DSA-87 · OS                                 | 988.53 μs | 19.247 μs | 29.965 μs |         - |
| Sign · ML-DSA-87 · BouncyCastle                       | 988.63 μs | 18.934 μs | 22.539 μs |  242554 B |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 394.56 μs |  6.181 μs |  5.480 μs |   93270 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 398.35 μs |  7.020 μs |  6.567 μs |   93175 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 489.59 μs |  9.655 μs | 11.493 μs |  104680 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 562.78 μs | 11.225 μs | 12.010 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 638.21 μs | 12.388 μs | 13.769 μs |  140235 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 639.27 μs | 12.613 μs | 11.798 μs |  139655 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 801.66 μs | 14.796 μs | 13.840 μs |  170448 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 894.53 μs | 17.656 μs | 25.879 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 795.38 μs | 13.040 μs | 12.198 μs |  200295 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 797.62 μs | 10.221 μs |  9.060 μs |  201287 B |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 977.77 μs | 18.961 μs | 28.955 μs |  241616 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 978.31 μs | 18.923 μs | 21.033 μs |         - |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  75.76 μs |  0.673 μs |  0.630 μs |         - |
| Verify · ML-DSA-44 · CryptoHives                      | 116.00 μs |  0.337 μs |  0.315 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives-Stateless            | 116.00 μs |  0.565 μs |  0.529 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     | 132.17 μs |  0.278 μs |  0.232 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               | 103.39 μs |  0.374 μs |  0.312 μs |         - |
| Verify · ML-DSA-65 · CryptoHives                      | 188.16 μs |  0.527 μs |  0.467 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 188.54 μs |  0.710 μs |  0.664 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 218.72 μs |  0.287 μs |  0.269 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               | 144.63 μs |  0.553 μs |  0.517 μs |         - |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 311.09 μs |  0.838 μs |  0.700 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives                      | 311.64 μs |  1.195 μs |  1.060 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 356.23 μs |  0.945 μs |  0.884 μs |  158544 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  71.54 μs |  0.380 μs |  0.317 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           | 113.64 μs |  0.503 μs |  0.470 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless | 113.76 μs |  0.599 μs |  0.561 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          | 132.70 μs |  0.330 μs |  0.275 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  99.01 μs |  0.382 μs |  0.338 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 185.57 μs |  0.849 μs |  0.794 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 185.69 μs |  0.542 μs |  0.507 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 219.97 μs |  0.605 μs |  0.566 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    | 141.28 μs |  1.035 μs |  0.968 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 308.49 μs |  0.767 μs |  0.718 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 309.12 μs |  1.137 μs |  1.008 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 355.06 μs |  0.660 μs |  0.585 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  75.33 μs |  0.461 μs |  0.385 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives            | 115.76 μs |  0.293 μs |  0.229 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  | 116.18 μs |  0.544 μs |  0.509 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           | 128.98 μs |  0.242 μs |  0.227 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     | 102.78 μs |  0.182 μs |  0.161 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 188.12 μs |  0.605 μs |  0.566 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 188.36 μs |  0.605 μs |  0.566 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 214.52 μs |  0.280 μs |  0.234 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     | 144.86 μs |  0.549 μs |  0.514 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 311.41 μs |  1.060 μs |  0.940 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 311.71 μs |  0.560 μs |  0.497 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 360.84 μs |  0.723 μs |  0.676 μs |  158544 B |