| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  19.89 μs | 0.094 μs | 0.088 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  38.10 μs | 0.158 μs | 0.148 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  38.72 μs | 0.235 μs | 0.208 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  45.62 μs | 0.061 μs | 0.057 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  75.41 μs | 0.139 μs | 0.123 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  25.90 μs | 0.105 μs | 0.093 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  60.81 μs | 0.057 μs | 0.050 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  61.97 μs | 0.440 μs | 0.390 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  73.44 μs | 0.151 μs | 0.134 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 116.87 μs | 0.301 μs | 0.251 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  33.98 μs | 0.081 μs | 0.068 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  90.25 μs | 0.135 μs | 0.105 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  91.77 μs | 0.321 μs | 0.285 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 109.35 μs | 0.342 μs | 0.320 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 175.23 μs | 0.762 μs | 0.636 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  31.64 μs | 0.632 μs | 0.621 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  52.86 μs | 0.252 μs | 0.223 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  56.13 μs | 0.204 μs | 0.170 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  59.37 μs | 0.045 μs | 0.042 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 104.97 μs | 0.294 μs | 0.246 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  41.06 μs | 0.242 μs | 0.215 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  80.80 μs | 0.505 μs | 0.472 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  85.27 μs | 0.543 μs | 0.481 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  94.53 μs | 0.501 μs | 0.444 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 159.16 μs | 1.318 μs | 1.100 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  53.51 μs | 0.300 μs | 0.250 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 115.76 μs | 0.163 μs | 0.145 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 121.21 μs | 0.616 μs | 0.546 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 140.33 μs | 2.613 μs | 2.683 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 231.03 μs | 0.889 μs | 0.743 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  31.44 μs | 0.270 μs | 0.253 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  52.93 μs | 0.248 μs | 0.220 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  55.96 μs | 0.115 μs | 0.096 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  60.30 μs | 0.040 μs | 0.033 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 103.58 μs | 0.285 μs | 0.238 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  41.23 μs | 0.366 μs | 0.342 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  81.43 μs | 0.714 μs | 0.668 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  86.14 μs | 1.524 μs | 1.425 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  94.10 μs | 0.399 μs | 0.353 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 157.27 μs | 0.798 μs | 0.707 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  53.68 μs | 0.400 μs | 0.374 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 118.62 μs | 1.824 μs | 1.706 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 124.80 μs | 2.449 μs | 2.620 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 136.52 μs | 0.711 μs | 0.665 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 229.47 μs | 0.168 μs | 0.149 μs |   42072 B |