| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  15.13 μs | 0.248 μs | 0.232 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  29.05 μs | 0.443 μs | 0.415 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  29.48 μs | 0.359 μs | 0.336 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  35.65 μs | 0.638 μs | 0.597 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  57.96 μs | 0.766 μs | 0.717 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  19.60 μs | 0.341 μs | 0.319 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  46.53 μs | 0.570 μs | 0.533 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  47.20 μs | 0.608 μs | 0.568 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  56.39 μs | 0.777 μs | 0.727 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  89.83 μs | 1.135 μs | 1.062 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  25.91 μs | 0.294 μs | 0.275 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  69.14 μs | 0.640 μs | 0.599 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  70.06 μs | 0.785 μs | 0.734 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  85.30 μs | 1.293 μs | 1.209 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 136.13 μs | 2.124 μs | 1.987 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  23.55 μs | 0.383 μs | 0.359 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  40.32 μs | 0.575 μs | 0.538 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  42.37 μs | 0.576 μs | 0.539 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  47.36 μs | 0.802 μs | 0.750 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  81.14 μs | 1.166 μs | 1.091 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  31.08 μs | 0.458 μs | 0.429 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  61.73 μs | 1.074 μs | 1.004 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  64.46 μs | 0.983 μs | 0.919 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  72.55 μs | 0.630 μs | 0.589 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 130.17 μs | 0.828 μs | 0.774 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  40.54 μs | 0.623 μs | 0.583 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  88.69 μs | 1.368 μs | 1.280 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  92.12 μs | 1.627 μs | 1.522 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 104.60 μs | 1.273 μs | 1.190 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 180.14 μs | 1.678 μs | 1.570 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  23.01 μs | 0.098 μs | 0.092 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  40.35 μs | 0.637 μs | 0.596 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  42.55 μs | 0.627 μs | 0.586 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  46.51 μs | 0.789 μs | 0.738 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  82.58 μs | 0.323 μs | 0.302 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  30.21 μs | 0.053 μs | 0.049 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  59.46 μs | 0.075 μs | 0.066 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  63.08 μs | 0.200 μs | 0.167 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  71.75 μs | 0.170 μs | 0.151 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 124.43 μs | 0.288 μs | 0.269 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  39.36 μs | 0.056 μs | 0.052 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  85.57 μs | 0.138 μs | 0.129 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  90.16 μs | 0.157 μs | 0.147 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 101.78 μs | 0.291 μs | 0.272 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 177.52 μs | 0.254 μs | 0.225 μs |   42072 B |