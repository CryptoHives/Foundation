| Description                                                  | Mean      | Error     | StdDev    | Median    | Allocated |
|------------------------------------------------------------- |----------:|----------:|----------:|----------:|----------:|
| Encapsulate · ML-KEM-512 · CryptoHives                       |  14.65 μs |  0.012 μs |  0.011 μs |  14.65 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  14.82 μs |  0.030 μs |  0.025 μs |  14.81 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  16.26 μs |  0.017 μs |  0.015 μs |  16.25 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  29.63 μs |  0.021 μs |  0.017 μs |  29.63 μs |   15560 B |
|                                                              |           |           |           |           |           |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  23.18 μs |  0.042 μs |  0.037 μs |  23.17 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  23.41 μs |  0.024 μs |  0.021 μs |  23.41 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  25.82 μs |  0.011 μs |  0.010 μs |  25.82 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  50.13 μs |  0.767 μs |  0.718 μs |  50.39 μs |   25120 B |
|                                                              |           |           |           |           |           |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  37.12 μs |  0.660 μs |  0.706 μs |  37.55 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  38.77 μs |  0.773 μs |  1.354 μs |  38.43 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  44.64 μs |  0.892 μs |  1.631 μs |  44.69 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  84.07 μs |  0.942 μs |  0.882 μs |  84.18 μs |   37248 B |
|                                                              |           |           |           |           |           |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  22.48 μs |  0.015 μs |  0.012 μs |  22.48 μs |   16976 B |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  24.90 μs |  0.250 μs |  0.233 μs |  24.92 μs |         - |
| Decapsulate · ML-KEM-512 · KyberNET                          |  40.03 μs |  0.030 μs |  0.028 μs |  40.02 μs |   17952 B |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  65.98 μs | 14.401 μs | 42.461 μs | 104.11 μs |         - |
|                                                              |           |           |           |           |           |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  31.53 μs |  0.031 μs |  0.026 μs |  31.53 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  33.05 μs |  0.041 μs |  0.034 μs |  33.05 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  34.91 μs |  0.244 μs |  0.228 μs |  35.04 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  61.98 μs |  0.023 μs |  0.018 μs |  61.98 μs |   28408 B |
|                                                              |           |           |           |           |           |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  44.72 μs |  0.370 μs |  0.309 μs |  44.63 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  46.60 μs |  0.042 μs |  0.033 μs |  46.59 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  49.57 μs |  0.020 μs |  0.018 μs |  49.57 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         |  91.05 μs |  0.225 μs |  0.199 μs |  91.03 μs |   42072 B |
|                                                              |           |           |           |           |           |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  21.11 μs |  0.016 μs |  0.015 μs |  21.10 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  22.12 μs |  0.013 μs |  0.011 μs |  22.11 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  22.46 μs |  0.012 μs |  0.011 μs |  22.47 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  40.14 μs |  0.060 μs |  0.056 μs |  40.12 μs |   17952 B |
|                                                              |           |           |           |           |           |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  31.55 μs |  0.025 μs |  0.023 μs |  31.56 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  34.43 μs |  0.688 μs |  0.919 μs |  34.69 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  37.30 μs |  0.160 μs |  0.141 μs |  37.31 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  69.34 μs |  0.372 μs |  0.330 μs |  69.18 μs |   28408 B |
|                                                              |           |           |           |           |           |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  51.10 μs |  1.012 μs |  2.022 μs |  50.96 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  55.98 μs |  1.119 μs |  2.456 μs |  56.65 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  58.92 μs |  1.153 μs |  1.417 μs |  58.81 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 111.30 μs |  0.599 μs |  0.468 μs | 111.19 μs |   42072 B |