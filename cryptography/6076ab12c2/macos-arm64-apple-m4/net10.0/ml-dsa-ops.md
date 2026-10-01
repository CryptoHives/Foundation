| Description                                           | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------ |----------:|---------:|---------:|----------:|
| Sign · ML-DSA-44 · CryptoHives                        | 166.41 μs | 1.999 μs | 1.870 μs |   90.7 KB |
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 166.65 μs | 2.178 μs | 2.037 μs |  90.64 KB |
| Sign · ML-DSA-44 · BouncyCastle                       | 174.23 μs | 2.047 μs | 1.915 μs |  103.7 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 269.77 μs | 5.127 μs | 4.796 μs | 134.85 KB |
| Sign · ML-DSA-65 · CryptoHives                        | 271.84 μs | 2.959 μs | 2.768 μs | 135.78 KB |
| Sign · ML-DSA-65 · BouncyCastle                       | 286.66 μs | 4.239 μs | 3.966 μs | 164.78 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-87 · CryptoHives                        | 334.41 μs | 4.503 μs | 4.212 μs | 194.99 KB |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 334.76 μs | 4.194 μs | 3.717 μs | 194.93 KB |
| Sign · ML-DSA-87 · BouncyCastle                       | 349.09 μs | 4.054 μs | 3.594 μs | 237.69 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 165.76 μs | 1.354 μs | 1.266 μs |  90.62 KB |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 166.54 μs | 1.403 μs | 1.312 μs |  90.96 KB |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 175.25 μs | 1.840 μs | 1.721 μs | 104.19 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 272.46 μs | 4.595 μs | 4.073 μs | 136.38 KB |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 273.30 μs | 4.391 μs | 4.107 μs | 136.03 KB |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 289.73 μs | 5.008 μs | 4.684 μs | 167.99 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 337.37 μs | 5.715 μs | 5.346 μs | 196.14 KB |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 338.48 μs | 4.073 μs | 3.610 μs |  196.2 KB |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 358.57 μs | 3.551 μs | 3.322 μs | 237.98 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-44 · BouncyCastle                     |  45.44 μs | 0.067 μs | 0.063 μs |  55.66 KB |
| Verify · ML-DSA-44 · CryptoHives                      |  46.51 μs | 0.109 μs | 0.102 μs |   49.3 KB |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  46.57 μs | 0.157 μs | 0.140 μs |   49.3 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-65 · BouncyCastle                     |  73.91 μs | 0.180 μs | 0.168 μs |  92.81 KB |
| Verify · ML-DSA-65 · CryptoHives                      |  74.62 μs | 0.140 μs | 0.131 μs |  79.54 KB |
| Verify · ML-DSA-65 · CryptoHives-Stateless            |  74.70 μs | 0.213 μs | 0.178 μs |  79.54 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 121.90 μs | 0.146 μs | 0.136 μs | 128.96 KB |
| Verify · ML-DSA-87 · CryptoHives                      | 122.05 μs | 0.228 μs | 0.213 μs | 128.96 KB |
| Verify · ML-DSA-87 · BouncyCastle                     | 122.13 μs | 0.223 μs | 0.197 μs | 154.83 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  45.43 μs | 0.064 μs | 0.057 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  45.48 μs | 0.080 μs | 0.075 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  47.19 μs | 0.110 μs | 0.103 μs |  56.07 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           |  73.53 μs | 0.164 μs | 0.153 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless |  73.60 μs | 0.137 μs | 0.121 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          |  75.63 μs | 0.112 μs | 0.099 μs |  93.23 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 120.82 μs | 0.205 μs | 0.182 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 120.99 μs | 0.259 μs | 0.230 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 126.25 μs | 0.239 μs | 0.223 μs | 155.24 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  46.18 μs | 0.051 μs | 0.045 μs |  55.66 KB |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  46.40 μs | 0.068 μs | 0.064 μs |   49.3 KB |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  46.53 μs | 0.134 μs | 0.119 μs |   49.3 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           |  74.05 μs | 0.186 μs | 0.174 μs |  92.81 KB |
| Verify (invalid) · ML-DSA-65 · CryptoHives            |  74.54 μs | 0.145 μs | 0.135 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  |  74.60 μs | 0.194 μs | 0.181 μs |  79.54 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 121.88 μs | 0.272 μs | 0.241 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 122.00 μs | 0.358 μs | 0.335 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 124.42 μs | 0.106 μs | 0.099 μs | 154.83 KB |