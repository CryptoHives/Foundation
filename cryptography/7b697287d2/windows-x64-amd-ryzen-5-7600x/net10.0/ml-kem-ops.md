| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  10.90 μs | 0.016 μs | 0.015 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  24.63 μs | 0.044 μs | 0.039 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  24.85 μs | 0.038 μs | 0.035 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  29.09 μs | 0.039 μs | 0.037 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  40.42 μs | 0.127 μs | 0.118 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  14.66 μs | 0.016 μs | 0.015 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  39.04 μs | 0.048 μs | 0.042 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  39.52 μs | 0.114 μs | 0.107 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  46.12 μs | 0.114 μs | 0.107 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  64.39 μs | 0.222 μs | 0.207 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  19.73 μs | 0.049 μs | 0.043 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  57.39 μs | 0.067 μs | 0.059 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  57.96 μs | 0.042 μs | 0.035 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  67.83 μs | 0.203 μs | 0.180 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  92.58 μs | 0.263 μs | 0.246 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  16.42 μs | 0.030 μs | 0.028 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  34.85 μs | 0.041 μs | 0.038 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  36.77 μs | 0.053 μs | 0.050 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  39.01 μs | 0.126 μs | 0.112 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  58.30 μs | 0.074 μs | 0.069 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  22.15 μs | 0.044 μs | 0.041 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  52.80 μs | 0.066 μs | 0.062 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  55.43 μs | 0.067 μs | 0.060 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  59.38 μs | 0.092 μs | 0.086 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  88.14 μs | 0.131 μs | 0.122 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  29.22 μs | 0.023 μs | 0.021 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  75.26 μs | 0.154 μs | 0.144 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  77.96 μs | 0.138 μs | 0.129 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  84.70 μs | 0.207 μs | 0.194 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 126.23 μs | 0.400 μs | 0.374 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  16.46 μs | 0.035 μs | 0.033 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  34.81 μs | 0.064 μs | 0.060 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  36.65 μs | 0.065 μs | 0.061 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  39.15 μs | 0.139 μs | 0.130 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  57.72 μs | 0.067 μs | 0.053 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  22.15 μs | 0.044 μs | 0.042 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  53.25 μs | 0.066 μs | 0.059 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  54.93 μs | 0.054 μs | 0.045 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  59.66 μs | 0.062 μs | 0.058 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  88.39 μs | 0.257 μs | 0.228 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  29.31 μs | 0.033 μs | 0.030 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  75.03 μs | 0.146 μs | 0.136 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  78.70 μs | 0.143 μs | 0.127 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  85.55 μs | 0.143 μs | 0.127 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 124.69 μs | 0.200 μs | 0.167 μs |   42072 B |