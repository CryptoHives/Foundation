| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  10.74 μs | 0.026 μs | 0.022 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  24.67 μs | 0.037 μs | 0.033 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  24.91 μs | 0.034 μs | 0.030 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  29.21 μs | 0.129 μs | 0.121 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  41.09 μs | 0.095 μs | 0.085 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  14.75 μs | 0.015 μs | 0.014 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  39.25 μs | 0.042 μs | 0.037 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  39.61 μs | 0.057 μs | 0.048 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  45.98 μs | 0.071 μs | 0.063 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  63.85 μs | 0.107 μs | 0.089 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  19.62 μs | 0.016 μs | 0.012 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  57.73 μs | 0.041 μs | 0.037 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  58.38 μs | 0.054 μs | 0.045 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  68.28 μs | 0.105 μs | 0.093 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  94.28 μs | 0.074 μs | 0.062 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  16.40 μs | 0.020 μs | 0.018 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  35.07 μs | 0.027 μs | 0.024 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  36.72 μs | 0.065 μs | 0.058 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  38.90 μs | 0.054 μs | 0.045 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  56.63 μs | 0.081 μs | 0.068 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  22.20 μs | 0.051 μs | 0.046 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  53.07 μs | 0.059 μs | 0.055 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  55.13 μs | 0.299 μs | 0.249 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  59.79 μs | 0.079 μs | 0.061 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  85.89 μs | 0.156 μs | 0.130 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  29.31 μs | 0.047 μs | 0.039 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  75.40 μs | 0.084 μs | 0.079 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  78.68 μs | 0.113 μs | 0.088 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  86.08 μs | 0.162 μs | 0.144 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 125.28 μs | 0.280 μs | 0.248 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  16.40 μs | 0.032 μs | 0.028 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  35.63 μs | 0.045 μs | 0.040 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  36.58 μs | 0.056 μs | 0.049 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  39.03 μs | 0.085 μs | 0.080 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  56.26 μs | 0.105 μs | 0.093 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  22.21 μs | 0.032 μs | 0.027 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  52.97 μs | 0.068 μs | 0.061 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  55.01 μs | 0.036 μs | 0.028 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  59.50 μs | 0.221 μs | 0.196 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  85.45 μs | 0.099 μs | 0.077 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  29.32 μs | 0.079 μs | 0.070 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  75.40 μs | 0.152 μs | 0.135 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  79.04 μs | 0.158 μs | 0.132 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  85.31 μs | 0.247 μs | 0.219 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 124.63 μs | 0.237 μs | 0.198 μs |   42072 B |