| Description                                                  | Mean      | Error     | StdDev    | Median    | Allocated |
|------------------------------------------------------------- |----------:|----------:|----------:|----------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  10.99 μs |  0.054 μs |  0.050 μs |  10.99 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  24.65 μs |  0.069 μs |  0.054 μs |  24.65 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  25.17 μs |  0.478 μs |  0.447 μs |  24.91 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  29.77 μs |  0.211 μs |  0.187 μs |  29.75 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  41.57 μs |  0.309 μs |  0.258 μs |  41.49 μs |   15560 B |
|                                                              |           |           |           |           |           |
| Encapsulate · ML-KEM-768 · OS                                |  14.68 μs |  0.176 μs |  0.165 μs |  14.58 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  39.15 μs |  0.095 μs |  0.084 μs |  39.13 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  39.53 μs |  0.133 μs |  0.118 μs |  39.49 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  46.67 μs |  0.231 μs |  0.193 μs |  46.61 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  63.44 μs |  0.146 μs |  0.122 μs |  63.41 μs |   25120 B |
|                                                              |           |           |           |           |           |
| Encapsulate · ML-KEM-1024 · OS                               |  19.67 μs |  0.115 μs |  0.102 μs |  19.64 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  57.38 μs |  0.051 μs |  0.042 μs |  57.38 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  57.94 μs |  0.082 μs |  0.064 μs |  57.93 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  68.33 μs |  0.105 μs |  0.093 μs |  68.35 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  94.36 μs |  0.197 μs |  0.154 μs |  94.43 μs |   37248 B |
|                                                              |           |           |           |           |           |
| Decapsulate · ML-KEM-512 · OS                                |  16.45 μs |  0.034 μs |  0.032 μs |  16.44 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  34.81 μs |  0.048 μs |  0.038 μs |  34.81 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  36.35 μs |  0.102 μs |  0.090 μs |  36.36 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  39.36 μs |  0.228 μs |  0.178 μs |  39.34 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  58.65 μs |  0.269 μs |  0.224 μs |  58.58 μs |   17952 B |
|                                                              |           |           |           |           |           |
| Decapsulate · ML-KEM-768 · OS                                |  22.54 μs |  0.236 μs |  0.197 μs |  22.61 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  53.79 μs |  0.513 μs |  0.480 μs |  53.57 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  55.22 μs |  0.266 μs |  0.236 μs |  55.14 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  60.02 μs |  0.189 μs |  0.158 μs |  59.96 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  88.64 μs |  0.289 μs |  0.241 μs |  88.56 μs |   28408 B |
|                                                              |           |           |           |           |           |
| Decapsulate · ML-KEM-1024 · OS                               |  29.40 μs |  0.178 μs |  0.166 μs |  29.32 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  76.64 μs |  0.937 μs |  0.830 μs |  76.25 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  77.98 μs |  0.134 μs |  0.105 μs |  77.97 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  86.62 μs |  1.549 μs |  1.294 μs |  86.15 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 126.82 μs |  0.691 μs |  0.613 μs | 126.62 μs |   42072 B |
|                                                              |           |           |           |           |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  16.49 μs |  0.106 μs |  0.088 μs |  16.45 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  35.48 μs |  0.468 μs |  0.391 μs |  35.29 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  36.37 μs |  0.101 μs |  0.090 μs |  36.35 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  40.06 μs |  0.205 μs |  0.171 μs |  39.99 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  58.93 μs |  0.164 μs |  0.146 μs |  58.95 μs |   17952 B |
|                                                              |           |           |           |           |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  22.26 μs |  0.129 μs |  0.108 μs |  22.22 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  53.49 μs |  0.737 μs |  0.653 μs |  53.24 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  56.47 μs |  0.864 μs |  0.808 μs |  56.39 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  60.53 μs |  0.869 μs |  0.726 μs |  60.57 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  91.37 μs |  1.079 μs |  0.901 μs |  91.08 μs |   28408 B |
|                                                              |           |           |           |           |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  31.34 μs |  0.618 μs |  1.235 μs |  30.93 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  76.21 μs |  1.049 μs |  0.930 μs |  76.09 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  79.31 μs |  0.635 μs |  0.563 μs |  79.23 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  87.20 μs |  1.161 μs |  1.029 μs |  87.01 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 177.19 μs | 13.411 μs | 39.542 μs | 158.62 μs |   42072 B |