| Description                                     | TestDataSize | Mean              | Error          | StdDev         | Code Size | Allocated |
|------------------------------------------------ |------------- |------------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |          42.63 ns |       0.058 ns |       0.054 ns |   9,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |          42.64 ns |       0.066 ns |       0.055 ns |   9,806 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 4B           |          42.68 ns |       0.077 ns |       0.069 ns |   9,806 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |          43.00 ns |       0.034 ns |       0.030 ns |   3,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |          43.01 ns |       0.033 ns |       0.029 ns |   3,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |          66.95 ns |       0.109 ns |       0.102 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |          69.07 ns |       0.027 ns |       0.024 ns |  12,439 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |          91.52 ns |       0.166 ns |       0.147 ns |  22,125 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |         718.85 ns |       1.297 ns |       1.083 ns |  22,808 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |          42.00 ns |       0.023 ns |       0.020 ns |   3,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |          42.01 ns |       0.031 ns |       0.029 ns |   3,986 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 64B          |          42.38 ns |       0.034 ns |       0.030 ns |   9,806 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |          42.42 ns |       0.097 ns |       0.081 ns |   9,806 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |          42.42 ns |       0.079 ns |       0.070 ns |  10,021 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |          48.99 ns |       0.096 ns |       0.075 ns |  12,249 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |          63.11 ns |       0.063 ns |       0.049 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |          86.21 ns |       0.273 ns |       0.228 ns |  22,125 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |         722.41 ns |       1.600 ns |       1.418 ns |  22,808 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |          90.58 ns |       0.053 ns |       0.049 ns |   6,009 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |          90.59 ns |       0.056 ns |       0.053 ns |   6,009 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 65B          |          92.65 ns |       0.066 ns |       0.055 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |          92.68 ns |       0.083 ns |       0.074 ns |  11,805 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |          92.69 ns |       0.099 ns |       0.083 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |         109.00 ns |       0.129 ns |       0.108 ns |  12,421 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         120.40 ns |       0.077 ns |       0.068 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |         180.76 ns |       0.464 ns |       0.412 ns |  15,790 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |       1,464.23 ns |       5.000 ns |       4.677 ns |  16,225 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |          90.64 ns |       0.045 ns |       0.042 ns |   6,009 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |          90.64 ns |       0.067 ns |       0.063 ns |   6,009 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |          92.71 ns |       0.101 ns |       0.084 ns |  11,805 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 100B         |          92.73 ns |       0.108 ns |       0.096 ns |   7,772 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |          92.77 ns |       0.095 ns |       0.079 ns |   7,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |         109.30 ns |       0.172 ns |       0.152 ns |  12,421 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         118.94 ns |       0.061 ns |       0.058 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |         175.75 ns |       0.611 ns |       0.510 ns |  22,125 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |       1,464.93 ns |       3.541 ns |       3.312 ns |  22,560 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |          90.25 ns |       0.066 ns |       0.062 ns |   6,009 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |          90.26 ns |       0.056 ns |       0.047 ns |   6,009 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |          92.66 ns |       0.079 ns |       0.066 ns |  12,020 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |          92.69 ns |       0.081 ns |       0.064 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 128B         |          92.77 ns |       0.103 ns |       0.086 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |         105.16 ns |       0.123 ns |       0.102 ns |  12,421 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         118.87 ns |       0.079 ns |       0.074 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |         172.62 ns |       0.585 ns |       0.488 ns |  15,790 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |       1,452.43 ns |       2.113 ns |       1.764 ns |  16,225 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |         141.87 ns |       0.110 ns |       0.098 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 137B         |         141.97 ns |       0.180 ns |       0.169 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |         142.07 ns |       0.221 ns |       0.196 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |         142.32 ns |       0.103 ns |       0.097 ns |   8,271 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |         142.34 ns |       0.075 ns |       0.070 ns |   8,271 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |         166.20 ns |       0.160 ns |       0.134 ns |  12,421 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |         181.63 ns |       0.196 ns |       0.183 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |         265.67 ns |       0.299 ns |       0.233 ns |  22,315 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |       2,133.26 ns |       3.717 ns |       3.104 ns |  22,564 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |         778.90 ns |       0.238 ns |       0.211 ns |   5,937 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |         778.98 ns |       0.344 ns |       0.322 ns |   5,937 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |         781.00 ns |       0.235 ns |       0.196 ns |  11,805 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1000B        |         781.01 ns |       0.360 ns |       0.319 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |         781.10 ns |       0.260 ns |       0.231 ns |  11,805 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |         834.28 ns |       0.398 ns |       0.353 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |         908.82 ns |       0.183 ns |       0.143 ns |  12,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |       1,383.04 ns |       2.889 ns |       2.561 ns |  22,125 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      10,538.63 ns |      12.310 ns |       9.611 ns |  22,768 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |         778.63 ns |       0.390 ns |       0.365 ns |   5,937 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |         778.66 ns |       0.329 ns |       0.292 ns |   5,937 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |         781.28 ns |       0.361 ns |       0.338 ns |   7,772 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |         781.67 ns |       0.568 ns |       0.504 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1KB          |         781.99 ns |       0.474 ns |       0.443 ns |  11,615 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |         834.28 ns |       0.396 ns |       0.370 ns |     707 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |         905.10 ns |       0.339 ns |       0.317 ns |  12,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |       1,408.41 ns |       3.177 ns |       2.817 ns |  22,125 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      10,425.08 ns |      30.785 ns |      28.797 ns |  16,237 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |         864.85 ns |       0.488 ns |       0.457 ns |  10,559 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |         866.09 ns |       0.514 ns |       0.481 ns |  15,615 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |         920.19 ns |       0.443 ns |       0.393 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1025B        |         924.81 ns |       0.404 ns |       0.358 ns |  16,446 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |         925.08 ns |       0.356 ns |       0.316 ns |  10,116 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |         934.01 ns |       0.456 ns |       0.381 ns |  10,111 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |       1,064.19 ns |       0.662 ns |       0.587 ns |  13,802 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |       1,560.00 ns |       2.705 ns |       2.398 ns |  13,693 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      11,872.47 ns |      20.198 ns |      16.867 ns |  29,342 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |         858.36 ns |       0.361 ns |       0.337 ns |   6,997 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |         858.49 ns |       0.347 ns |       0.271 ns |  11,232 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |         859.56 ns |       0.164 ns |       0.146 ns |   6,997 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 2KB          |         860.89 ns |       0.495 ns |       0.386 ns |  17,762 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |         871.63 ns |       0.584 ns |       0.546 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |       1,256.70 ns |       2.952 ns |       2.465 ns |  22,357 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |       1,919.51 ns |       1.311 ns |       1.163 ns |   7,272 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |       2,775.97 ns |       4.752 ns |       3.968 ns |  20,220 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |      21,255.22 ns |      39.454 ns |      34.975 ns |  29,535 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |       1,033.87 ns |       0.619 ns |       0.548 ns |  15,599 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |       1,035.49 ns |       0.729 ns |       0.682 ns |  15,599 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |       1,069.48 ns |       0.689 ns |       0.611 ns |  19,134 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 3KB          |       1,072.30 ns |       1.025 ns |       0.909 ns |  19,329 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |       1,320.92 ns |       1.699 ns |       1.506 ns |  16,718 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |       1,709.50 ns |       0.632 ns |       0.528 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |       2,920.34 ns |       1.393 ns |       1.303 ns |  14,524 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |       4,204.56 ns |      11.940 ns |       9.971 ns |  20,184 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |      31,845.65 ns |     135.573 ns |     126.815 ns |  29,534 B |     112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |       1,027.25 ns |       1.113 ns |       1.042 ns |  11,495 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |       1,028.95 ns |       0.547 ns |       0.512 ns |  11,495 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 4KB          |       1,101.33 ns |       1.708 ns |       1.514 ns |  17,468 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |       1,102.08 ns |       1.241 ns |       1.161 ns |  23,993 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |       1,124.28 ns |       0.951 ns |       0.890 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |       1,358.95 ns |       2.227 ns |       1.974 ns |  22,154 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |       3,844.62 ns |       1.853 ns |       1.733 ns |  20,874 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |       5,615.14 ns |       7.919 ns |       6.613 ns |  13,840 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |      42,934.45 ns |      77.530 ns |      64.741 ns |  29,348 B |     168 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |       1,319.58 ns |       1.160 ns |       0.969 ns |  20,188 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |       1,320.62 ns |       0.975 ns |       0.912 ns |  20,188 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |       1,400.28 ns |       1.546 ns |       1.446 ns |  29,580 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 5KB          |       1,431.51 ns |       1.037 ns |       0.919 ns |  29,575 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |       1,991.22 ns |       0.825 ns |       0.772 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |       2,198.26 ns |       2.630 ns |       2.331 ns |  30,858 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |       4,867.36 ns |       3.672 ns |       3.435 ns |  20,824 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |       7,054.05 ns |       8.110 ns |       6.772 ns |  20,379 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |      53,848.30 ns |     128.121 ns |     113.576 ns |  29,534 B |     224 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |       1,324.99 ns |       1.473 ns |       1.230 ns |  26,795 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |       1,325.92 ns |       0.616 ns |       0.576 ns |  26,795 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |       1,420.85 ns |       1.544 ns |       1.444 ns |  23,055 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 6KB          |       1,451.85 ns |       2.269 ns |       2.011 ns |  29,575 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |       2,013.39 ns |       1.135 ns |       1.061 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |       2,650.17 ns |       3.160 ns |       2.802 ns |  29,910 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |       5,790.68 ns |       2.062 ns |       1.929 ns |  27,166 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |       8,504.81 ns |      15.238 ns |      13.508 ns |  20,170 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |      64,402.23 ns |     153.147 ns |     135.761 ns |  29,546 B |     280 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |       1,286.27 ns |       0.369 ns |       0.308 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |       1,333.92 ns |       0.943 ns |       0.882 ns |  26,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |       1,354.97 ns |       1.352 ns |       1.265 ns |  26,653 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |       1,373.53 ns |       1.090 ns |       1.020 ns |  26,653 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 8KB          |       1,420.58 ns |       1.344 ns |       1.257 ns |  27,097 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |       1,596.17 ns |       2.352 ns |       2.200 ns |  22,051 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |       2,745.96 ns |       3.284 ns |       2.742 ns |  29,456 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      11,364.84 ns |      21.124 ns |      18.726 ns |  20,170 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |      87,011.44 ns |     167.039 ns |     139.485 ns |  29,527 B |     392 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 9216B        |       2,129.41 ns |       1.214 ns |       1.136 ns |  23,435 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |       2,137.26 ns |       1.182 ns |       1.106 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |       2,174.55 ns |       1.991 ns |       1.862 ns |  22,951 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |       2,210.22 ns |       1.833 ns |       1.714 ns |  31,782 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |       2,212.65 ns |       1.908 ns |       1.785 ns |  31,782 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |       2,611.92 ns |       1.293 ns |       1.009 ns |  28,845 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |       3,591.27 ns |       2.426 ns |       1.894 ns |  31,048 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      12,710.71 ns |      12.156 ns |      10.151 ns |  20,374 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |      99,510.48 ns |     191.772 ns |     179.384 ns |  29,368 B |     448 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10000B       |       2,206.39 ns |       2.199 ns |       1.949 ns |  23,781 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |       2,217.89 ns |       1.492 ns |       1.396 ns |  37,404 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |       2,220.39 ns |       0.972 ns |       0.812 ns |  37,594 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |       2,283.35 ns |       1.491 ns |       1.394 ns |  24,265 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |       2,845.00 ns |       1.095 ns |       1.024 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |       3,358.14 ns |       3.668 ns |       3.431 ns |  28,853 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |       4,288.24 ns |       8.877 ns |       7.869 ns |  31,039 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      14,018.77 ns |      20.111 ns |      16.794 ns |  20,362 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     108,369.55 ns |     214.390 ns |     179.026 ns |  23,025 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10240B       |       2,129.82 ns |       1.752 ns |       1.638 ns |  23,440 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |       2,186.75 ns |       1.326 ns |       1.241 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |       2,216.34 ns |       2.892 ns |       2.705 ns |  28,777 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |       2,217.64 ns |       1.082 ns |       0.959 ns |  28,777 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |       2,316.22 ns |       1.425 ns |       1.333 ns |  30,389 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |       3,533.19 ns |       2.455 ns |       2.296 ns |  28,848 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |       4,054.03 ns |      12.439 ns |      11.027 ns |  23,385 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      14,254.44 ns |      19.557 ns |      16.331 ns |  20,175 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     109,621.19 ns |     349.458 ns |     326.883 ns |  29,546 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 11264B       |       2,197.74 ns |       1.498 ns |       1.328 ns |  29,952 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |       2,341.08 ns |       2.125 ns |       1.988 ns |  31,398 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |       2,384.56 ns |       3.092 ns |       2.741 ns |  31,398 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |       2,442.60 ns |       1.958 ns |       1.735 ns |  24,735 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |       3,009.54 ns |       1.952 ns |       1.826 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |       4,113.31 ns |      12.879 ns |      11.417 ns |  23,390 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |       4,447.93 ns |       4.609 ns |       4.085 ns |  28,848 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      15,668.48 ns |      43.716 ns |      36.505 ns |  13,835 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     120,608.58 ns |     273.913 ns |     242.817 ns |  29,532 B |     560 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 12288B       |       2,158.34 ns |       2.260 ns |       2.114 ns |  29,775 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |       2,324.01 ns |      20.123 ns |      16.804 ns |  34,825 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |       2,330.04 ns |       3.863 ns |       3.226 ns |  34,825 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |       2,423.74 ns |       0.990 ns |       0.877 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |       2,464.98 ns |       1.625 ns |       1.520 ns |  31,265 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |       4,136.59 ns |      10.748 ns |       8.391 ns |  29,456 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |       5,374.28 ns |       3.176 ns |       2.653 ns |  22,325 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      16,971.26 ns |      30.542 ns |      25.504 ns |  13,840 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     131,585.55 ns |     339.598 ns |     317.661 ns |  29,538 B |     616 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |       2,353.44 ns |       2.245 ns |       1.753 ns |  34,840 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 15360B       |       2,358.09 ns |       2.000 ns |       1.670 ns |  29,947 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |       2,405.56 ns |       2.269 ns |       1.894 ns |  31,972 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |       2,825.05 ns |       3.568 ns |       3.163 ns |  35,766 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |       4,046.83 ns |       2.463 ns |       2.304 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |       5,493.71 ns |      11.394 ns |      10.100 ns |  29,720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |       8,122.86 ns |       9.143 ns |       8.552 ns |  22,551 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |      22,527.47 ns |      34.795 ns |      29.055 ns |  20,360 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     162,774.54 ns |     206.352 ns |     172.313 ns |  29,550 B |     784 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |       2,101.85 ns |       2.022 ns |       1.793 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 16KB         |       2,168.48 ns |       2.019 ns |       1.888 ns |  28,092 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |       2,179.23 ns |       2.863 ns |       2.236 ns |  27,730 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |       2,180.96 ns |       2.014 ns |       1.884 ns |  27,730 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |       2,573.20 ns |       3.979 ns |       3.528 ns |  28,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |       2,716.57 ns |       1.660 ns |       1.553 ns |  21,549 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |       5,525.81 ns |      10.569 ns |       8.826 ns |  29,456 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |      23,207.34 ns |      23.537 ns |      19.655 ns |  20,365 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     176,250.95 ns |     324.508 ns |     270.979 ns |  23,028 B |     840 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |       3,843.91 ns |       9.888 ns |       8.766 ns |  65,710 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |       8,043.72 ns |       6.024 ns |       5.634 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 64KB         |       8,336.21 ns |       7.256 ns |       6.432 ns |  28,560 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |       8,384.04 ns |       5.181 ns |       4.045 ns |  30,046 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |       9,663.05 ns |       4.878 ns |       4.325 ns |  27,268 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |       9,672.22 ns |      12.655 ns |      10.568 ns |  29,223 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |      20,641.80 ns |      36.932 ns |      30.840 ns |  29,245 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |      91,325.51 ns |     125.804 ns |      98.219 ns |  20,170 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |     697,926.10 ns |   1,594.585 ns |   1,413.558 ns |  29,625 B |    3528 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |       5,295.63 ns |      12.703 ns |      11.883 ns |  71,094 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |      13,475.09 ns |       9.348 ns |       8.744 ns |  42,505 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |      13,574.54 ns |       7.161 ns |       6.698 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 100000B      |      13,829.99 ns |       6.127 ns |       5.731 ns |  32,258 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |      16,056.85 ns |      10.861 ns |      10.159 ns |  31,146 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |      17,781.50 ns |      15.252 ns |      13.521 ns |  23,003 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |      33,202.57 ns |      55.149 ns |      48.888 ns |  31,390 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     141,118.67 ns |     176.963 ns |     147.772 ns |  13,835 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |   1,065,212.99 ns |   1,638.439 ns |   1,452.433 ns |  29,434 B |    5432 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |       6,408.77 ns |      60.286 ns |      56.392 ns |  67,297 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |      15,917.62 ns |      10.896 ns |      10.192 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 128KB        |      16,740.76 ns |      10.217 ns |       9.057 ns |  23,007 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |      16,849.66 ns |      10.334 ns |       9.161 ns |  30,046 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |      19,356.44 ns |      12.873 ns |      12.041 ns |  28,425 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |      19,398.21 ns |      34.950 ns |      32.692 ns |  29,206 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |      41,350.21 ns |      87.818 ns |      73.332 ns |  29,812 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |     186,257.05 ns |     270.807 ns |     240.063 ns |  20,175 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |   1,417,130.07 ns |   8,143.559 ns |   7,617.490 ns |  29,609 B |    7112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |      36,212.03 ns |      29.078 ns |      22.702 ns |  69,297 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |     122,583.92 ns |      56.492 ns |      47.173 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |     129,352.62 ns |     167.033 ns |     148.070 ns |  29,727 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1MB          |     132,309.42 ns |      87.423 ns |      81.775 ns |  30,730 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |     149,883.27 ns |      80.989 ns |      71.795 ns |  29,813 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |     164,103.08 ns |     105.828 ns |      88.371 ns |  23,006 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |     318,825.66 ns |     507.273 ns |     423.596 ns |  31,200 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |   1,419,568.16 ns |   6,110.395 ns |   5,102.457 ns |  20,175 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  10,750,103.96 ns |  21,535.043 ns |  20,143.893 ns |  29,534 B |   54656 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |     361,930.77 ns |   1,114.260 ns |     987.763 ns |  76,259 B |     153 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |   1,251,577.16 ns |   1,489.687 ns |   1,320.569 ns |     711 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |   1,409,639.44 ns |   3,053.694 ns |   2,707.020 ns |  36,119 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10MB         |   1,411,333.49 ns |   2,048.581 ns |   1,916.244 ns |  31,090 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |   1,520,756.69 ns |   3,300.540 ns |   2,756.100 ns |  29,347 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |   1,546,563.21 ns |   2,438.775 ns |   2,161.911 ns |  29,985 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |   3,209,287.14 ns |   7,129.396 ns |   6,320.024 ns |  31,395 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  14,158,331.98 ns |  44,127.387 ns |  41,276.785 ns |  20,317 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 106,071,292.86 ns | 232,001.493 ns | 205,663.280 ns |  23,088 B |  546840 B |