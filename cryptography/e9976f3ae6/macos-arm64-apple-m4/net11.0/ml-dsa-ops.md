| Description                                           | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------ |----------:|---------:|---------:|----------:|
| Sign · ML-DSA-44 · CryptoHives                        | 163.07 μs | 2.132 μs | 1.994 μs |  90.69 KB |
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 163.41 μs | 1.588 μs | 1.486 μs |  90.48 KB |
| Sign · ML-DSA-44 · BouncyCastle                       | 177.61 μs | 1.807 μs | 1.690 μs | 102.95 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-65 · CryptoHives                        | 265.36 μs | 3.443 μs | 3.220 μs | 136.31 KB |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 267.44 μs | 4.873 μs | 4.558 μs | 135.03 KB |
| Sign · ML-DSA-65 · BouncyCastle                       | 287.58 μs | 4.322 μs | 4.043 μs | 166.32 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-87 · CryptoHives                        | 328.21 μs | 5.164 μs | 4.830 μs | 195.58 KB |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 329.50 μs | 5.296 μs | 4.954 μs | 194.84 KB |
| Sign · ML-DSA-87 · BouncyCastle                       | 350.80 μs | 2.883 μs | 2.251 μs | 236.38 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 160.31 μs | 1.768 μs | 1.654 μs |  90.85 KB |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 160.98 μs | 1.746 μs | 1.548 μs |  90.79 KB |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 174.23 μs | 1.958 μs | 1.736 μs | 103.69 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 263.19 μs | 3.452 μs | 3.229 μs | 135.69 KB |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 268.48 μs | 5.011 μs | 4.921 μs | 136.09 KB |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 285.61 μs | 3.940 μs | 3.686 μs | 166.79 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 327.47 μs | 3.771 μs | 3.527 μs | 195.61 KB |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 328.60 μs | 4.634 μs | 4.335 μs |  195.7 KB |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 350.72 μs | 4.731 μs | 4.425 μs | 238.04 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  45.07 μs | 0.068 μs | 0.063 μs |   49.3 KB |
| Verify · ML-DSA-44 · BouncyCastle                     |  45.36 μs | 0.121 μs | 0.113 μs |  55.65 KB |
| Verify · ML-DSA-44 · CryptoHives                      |  45.48 μs | 0.066 μs | 0.062 μs |   49.3 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-65 · CryptoHives                      |  72.57 μs | 0.272 μs | 0.255 μs |  79.54 KB |
| Verify · ML-DSA-65 · CryptoHives-Stateless            |  72.59 μs | 0.110 μs | 0.103 μs |  79.54 KB |
| Verify · ML-DSA-65 · BouncyCastle                     |  74.51 μs | 0.146 μs | 0.136 μs |   92.8 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-87 · CryptoHives                      | 119.24 μs | 0.216 μs | 0.202 μs | 128.96 KB |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 119.36 μs | 0.101 μs | 0.089 μs | 128.96 KB |
| Verify · ML-DSA-87 · BouncyCastle                     | 121.41 μs | 0.151 μs | 0.142 μs | 154.82 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  44.25 μs | 0.076 μs | 0.071 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  44.70 μs | 0.078 μs | 0.073 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  46.73 μs | 0.130 μs | 0.122 μs |  56.07 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless |  71.53 μs | 0.180 μs | 0.169 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           |  71.72 μs | 0.156 μs | 0.146 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          |  75.55 μs | 0.174 μs | 0.163 μs |  93.23 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 117.80 μs | 0.463 μs | 0.433 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 118.21 μs | 0.198 μs | 0.185 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 124.25 μs | 0.264 μs | 0.247 μs | 155.24 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  45.10 μs | 0.079 μs | 0.074 μs |   49.3 KB |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  45.23 μs | 0.097 μs | 0.090 μs |   49.3 KB |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  45.34 μs | 0.111 μs | 0.104 μs |  55.65 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  |  72.59 μs | 0.150 μs | 0.140 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · CryptoHives            |  72.66 μs | 0.126 μs | 0.118 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           |  73.64 μs | 0.139 μs | 0.130 μs |   92.8 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 118.71 μs | 0.074 μs | 0.065 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 118.99 μs | 0.171 μs | 0.160 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 121.31 μs | 0.150 μs | 0.133 μs | 154.82 KB |