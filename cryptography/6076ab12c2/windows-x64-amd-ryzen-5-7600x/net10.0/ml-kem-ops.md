| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  10.85 μs | 0.023 μs | 0.022 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  24.73 μs | 0.015 μs | 0.014 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  24.98 μs | 0.033 μs | 0.029 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  29.05 μs | 0.029 μs | 0.026 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  40.73 μs | 0.070 μs | 0.062 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  14.81 μs | 0.016 μs | 0.015 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  39.35 μs | 0.030 μs | 0.026 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  39.67 μs | 0.035 μs | 0.033 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  46.16 μs | 0.061 μs | 0.051 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  62.93 μs | 0.163 μs | 0.152 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  19.72 μs | 0.025 μs | 0.023 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  57.64 μs | 0.028 μs | 0.025 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  58.08 μs | 0.037 μs | 0.035 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  67.94 μs | 0.120 μs | 0.113 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  93.70 μs | 0.163 μs | 0.145 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  16.40 μs | 0.022 μs | 0.020 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  35.02 μs | 0.058 μs | 0.054 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  36.49 μs | 0.032 μs | 0.030 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  39.22 μs | 0.074 μs | 0.065 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  58.31 μs | 0.099 μs | 0.093 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  22.25 μs | 0.031 μs | 0.029 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  53.17 μs | 0.028 μs | 0.025 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  55.31 μs | 0.040 μs | 0.036 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  59.17 μs | 0.057 μs | 0.053 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  88.83 μs | 0.147 μs | 0.131 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  29.29 μs | 0.016 μs | 0.015 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  74.98 μs | 0.050 μs | 0.044 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  77.92 μs | 0.083 μs | 0.077 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  85.10 μs | 0.075 μs | 0.063 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 123.44 μs | 0.221 μs | 0.207 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  16.41 μs | 0.019 μs | 0.017 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  34.96 μs | 0.028 μs | 0.024 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  36.50 μs | 0.028 μs | 0.025 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  39.23 μs | 0.092 μs | 0.082 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  58.50 μs | 0.057 μs | 0.050 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  22.21 μs | 0.014 μs | 0.013 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  53.18 μs | 0.034 μs | 0.030 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  55.31 μs | 0.037 μs | 0.035 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  59.43 μs | 0.079 μs | 0.074 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  89.58 μs | 0.078 μs | 0.069 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  29.37 μs | 0.012 μs | 0.010 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  74.95 μs | 0.062 μs | 0.052 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  78.01 μs | 0.075 μs | 0.070 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  84.57 μs | 0.110 μs | 0.103 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 125.83 μs | 0.292 μs | 0.259 μs |   42072 B |