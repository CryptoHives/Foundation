| Description                                           | Mean      | Error     | StdDev    | Allocated |
|------------------------------------------------------ |----------:|----------:|----------:|----------:|
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 258.51 μs |  4.694 μs |  4.161 μs |   92687 B |
| Sign · ML-DSA-44 · CryptoHives                        | 259.31 μs |  4.966 μs |  4.646 μs |   92913 B |
| Sign · ML-DSA-44 · BouncyCastle                       | 295.59 μs |  4.071 μs |  3.808 μs |  104812 B |
| Sign · ML-DSA-44 · OS                                 | 354.34 μs |  6.001 μs |  5.613 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 423.01 μs |  6.600 μs |  6.173 μs |  139441 B |
| Sign · ML-DSA-65 · CryptoHives                        | 428.60 μs |  8.095 μs |  7.572 μs |  140133 B |
| Sign · ML-DSA-65 · BouncyCastle                       | 478.63 μs |  7.314 μs |  6.842 μs |  169167 B |
| Sign · ML-DSA-65 · OS                                 | 568.56 μs |  9.768 μs | 12.701 μs |         - |
|                                                       |           |           |           |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 519.01 μs |  8.721 μs |  7.731 μs |  199439 B |
| Sign · ML-DSA-87 · CryptoHives                        | 519.63 μs |  9.054 μs |  8.027 μs |  199450 B |
| Sign · ML-DSA-87 · BouncyCastle                       | 589.09 μs | 11.525 μs | 12.332 μs |  242084 B |
| Sign · ML-DSA-87 · OS                                 | 616.76 μs | 10.135 μs |  9.480 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 257.06 μs |  4.387 μs |  4.103 μs |   92960 B |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 257.71 μs |  3.391 μs |  3.172 μs |   93940 B |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 293.92 μs |  4.461 μs |  4.173 μs |  104391 B |
| Sign (pre-hash) · ML-DSA-44 · OS                      | 352.38 μs |  6.707 μs |  7.455 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 423.38 μs |  5.911 μs |  5.529 μs |  139788 B |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 427.03 μs |  8.353 μs |  8.204 μs |  139587 B |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 481.41 μs |  8.195 μs |  7.666 μs |  169235 B |
| Sign (pre-hash) · ML-DSA-65 · OS                      | 572.14 μs | 11.117 μs | 12.802 μs |         - |
|                                                       |           |           |           |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 520.10 μs |  9.787 μs | 10.879 μs |  199642 B |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 521.22 μs | 10.026 μs | 10.295 μs |  199941 B |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 589.85 μs | 11.070 μs | 11.844 μs |  240674 B |
| Sign (pre-hash) · ML-DSA-87 · OS                      | 620.23 μs | 12.140 μs | 11.923 μs |         - |
|                                                       |           |           |           |           |
| Verify · ML-DSA-44 · OS                               |  44.89 μs |  0.106 μs |  0.099 μs |         - |
| Verify · ML-DSA-44 · CryptoHives                      |  68.12 μs |  0.222 μs |  0.197 μs |   50488 B |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  68.23 μs |  0.307 μs |  0.287 μs |   50488 B |
| Verify · ML-DSA-44 · BouncyCastle                     |  75.11 μs |  0.242 μs |  0.226 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-65 · OS                               |  62.99 μs |  0.072 μs |  0.060 μs |         - |
| Verify · ML-DSA-65 · CryptoHives                      | 109.31 μs |  0.250 μs |  0.234 μs |   81448 B |
| Verify · ML-DSA-65 · CryptoHives-Stateless            | 109.34 μs |  0.273 μs |  0.228 μs |   81448 B |
| Verify · ML-DSA-65 · BouncyCastle                     | 121.90 μs |  0.455 μs |  0.426 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify · ML-DSA-87 · OS                               |  89.66 μs |  0.248 μs |  0.232 μs |         - |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 178.76 μs |  0.493 μs |  0.437 μs |  132056 B |
| Verify · ML-DSA-87 · CryptoHives                      | 179.13 μs |  0.555 μs |  0.492 μs |  132056 B |
| Verify · ML-DSA-87 · BouncyCastle                     | 201.26 μs |  0.521 μs |  0.462 μs |  158544 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-44 · OS                    |  43.04 μs |  0.127 μs |  0.113 μs |         - |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  66.78 μs |  0.294 μs |  0.246 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  69.05 μs |  0.334 μs |  0.296 μs |   50824 B |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  75.31 μs |  0.217 μs |  0.192 μs |   57416 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-65 · OS                    |  60.90 μs |  0.093 μs |  0.082 μs |         - |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless | 108.06 μs |  0.254 μs |  0.225 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           | 108.56 μs |  0.405 μs |  0.338 μs |   81784 B |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          | 122.07 μs |  0.437 μs |  0.409 μs |   95464 B |
|                                                       |           |           |           |           |
| Verify (pre-hash) · ML-DSA-87 · OS                    |  88.03 μs |  0.239 μs |  0.212 μs |         - |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 177.47 μs |  0.568 μs |  0.503 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 177.94 μs |  0.793 μs |  0.703 μs |  132392 B |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 202.04 μs |  1.061 μs |  0.886 μs |  158968 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-44 · OS                     |  44.94 μs |  0.118 μs |  0.105 μs |         - |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  68.33 μs |  0.266 μs |  0.249 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  68.48 μs |  0.391 μs |  0.346 μs |   50488 B |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  75.17 μs |  0.106 μs |  0.094 μs |   56992 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-65 · OS                     |  62.71 μs |  0.191 μs |  0.179 μs |         - |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  | 109.75 μs |  0.247 μs |  0.219 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · CryptoHives            | 109.84 μs |  0.406 μs |  0.380 μs |   81448 B |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           | 122.20 μs |  0.368 μs |  0.326 μs |   95040 B |
|                                                       |           |           |           |           |
| Verify (invalid) · ML-DSA-87 · OS                     |  89.88 μs |  0.259 μs |  0.230 μs |         - |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 178.88 μs |  0.733 μs |  0.650 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 179.17 μs |  0.534 μs |  0.500 μs |  132056 B |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 201.92 μs |  0.857 μs |  0.802 μs |  158544 B |