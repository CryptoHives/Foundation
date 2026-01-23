```
| Description                                                 | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**                    | **128B**         |       **131.1 ns** |      **2.29 ns** |      **2.14 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128B         |       145.8 ns |      2.82 ns |      2.77 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128B         |       400.4 ns |      5.52 ns |      5.16 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 137B         |       209.0 ns |      0.91 ns |      0.71 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 137B         |       244.8 ns |      1.50 ns |      1.17 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 137B         |       759.7 ns |      9.87 ns |      9.23 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1KB          |       753.5 ns |     13.27 ns |     12.41 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1KB          |       872.6 ns |     12.66 ns |     10.57 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1KB          |     2,889.1 ns |     33.49 ns |     29.69 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1025B        |       839.3 ns |     14.16 ns |     12.56 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1025B        |     1,001.9 ns |     20.00 ns |     34.49 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1025B        |     3,248.4 ns |     39.61 ns |     35.11 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 8KB          |     5,680.9 ns |     90.09 ns |     84.27 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 8KB          |     7,077.1 ns |    108.56 ns |    101.54 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 8KB          |    22,878.0 ns |    291.73 ns |    272.88 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 128KB        |    90,318.9 ns |  1,350.33 ns |  1,263.10 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128KB        |   112,559.7 ns |  1,726.56 ns |  1,615.02 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128KB        |   366,425.1 ns |  5,848.69 ns |  5,470.87 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128B         |       191.0 ns |      3.14 ns |      2.94 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128B         |       193.5 ns |      3.42 ns |      3.20 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128B         |       209.9 ns |      0.99 ns |      0.83 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128B         |       634.1 ns |      9.87 ns |      9.23 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 137B         |       261.7 ns |      0.70 ns |      0.55 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 137B         |       271.5 ns |      4.37 ns |      4.09 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 137B         |       306.3 ns |      5.35 ns |      5.00 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 137B         |       916.8 ns |     12.74 ns |     11.29 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1KB          |     1,246.7 ns |      7.65 ns |      6.38 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1KB          |     1,278.4 ns |     23.93 ns |     23.50 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1KB          |     1,433.5 ns |     22.80 ns |     21.33 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1KB          |     4,739.6 ns |     64.06 ns |     59.92 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1025B        |     1,322.7 ns |     10.05 ns |      8.39 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1025B        |     1,353.3 ns |     22.59 ns |     21.13 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1025B        |     1,515.5 ns |     10.42 ns |      8.13 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1025B        |     5,021.2 ns |     68.92 ns |     64.47 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 8KB          |     9,743.3 ns |     30.84 ns |     24.08 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 8KB          |     9,792.6 ns |    162.08 ns |    151.61 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 8KB          |    11,206.9 ns |    162.74 ns |    152.23 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 8KB          |    37,222.7 ns |    264.70 ns |    206.66 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128KB        |   156,312.2 ns |  2,530.05 ns |  2,366.61 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128KB        |   156,845.1 ns |  3,122.12 ns |  3,066.34 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128KB        |   178,764.0 ns |  3,016.23 ns |  2,821.38 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128KB        |   597,792.7 ns |  8,493.93 ns |  7,529.65 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 128B         |       115.1 ns |      1.84 ns |      1.72 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128B         |       394.4 ns |      6.20 ns |      5.80 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128B         |       575.4 ns |      3.37 ns |      2.81 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128B         |     1,265.0 ns |      9.88 ns |      8.76 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 137B         |       159.0 ns |      0.48 ns |      0.45 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 137B         |       446.3 ns |      1.13 ns |      1.00 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 137B         |       834.8 ns |      2.24 ns |      1.98 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 137B         |     1,852.6 ns |      4.66 ns |      4.13 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 1KB          |       764.6 ns |      1.82 ns |      1.70 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1KB          |     1,299.5 ns |      2.63 ns |      2.34 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1KB          |     4,217.2 ns |     16.78 ns |     15.70 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1KB          |     9,510.2 ns |     31.39 ns |     27.83 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 1025B        |       869.1 ns |      3.42 ns |      2.86 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1025B        |     1,487.0 ns |      3.26 ns |      2.89 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1025B        |     4,786.9 ns |     15.30 ns |     13.56 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1025B        |    10,775.4 ns |     24.90 ns |     23.29 ns |     168 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 8KB          |     1,188.6 ns |      3.48 ns |      3.25 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 8KB          |    10,365.7 ns |     40.06 ns |     37.47 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 8KB          |    35,380.3 ns |    134.50 ns |    125.81 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 8KB          |    79,980.4 ns |    129.03 ns |    114.38 ns |     504 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 128KB        |    14,303.5 ns |     52.83 ns |     44.11 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128KB        |   168,975.9 ns |    366.51 ns |    342.83 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128KB        |   570,486.0 ns |  1,273.43 ns |  1,191.17 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128KB        | 1,281,607.2 ns |  2,852.98 ns |  2,668.68 ns |    7224 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128B         |       273.8 ns |      0.99 ns |      0.88 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 128B         |       349.2 ns |      5.80 ns |      5.43 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128B         |       349.4 ns |      1.85 ns |      1.73 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128B         |       358.1 ns |      1.16 ns |      0.96 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 137B         |       269.5 ns |      1.28 ns |      1.13 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 137B         |       345.5 ns |      2.38 ns |      2.23 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 137B         |       352.1 ns |      5.62 ns |      5.26 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 137B         |       367.1 ns |      1.51 ns |      1.41 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1KB          |     1,530.0 ns |      5.85 ns |      5.47 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 1KB          |     2,031.4 ns |      7.48 ns |      6.63 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1KB          |     2,077.4 ns |      6.93 ns |      6.14 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1KB          |     2,195.6 ns |      8.83 ns |      7.83 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1025B        |     1,528.5 ns |      5.45 ns |      4.83 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 1025B        |     2,018.3 ns |      5.32 ns |      4.44 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1025B        |     2,075.9 ns |      8.15 ns |      7.63 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1025B        |     2,189.7 ns |     10.16 ns |      9.50 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 8KB          |     9,980.2 ns |     34.88 ns |     32.63 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 8KB          |    13,401.4 ns |     24.66 ns |     23.06 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 8KB          |    13,806.7 ns |     34.46 ns |     28.77 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 8KB          |    15,030.1 ns |     33.47 ns |     29.67 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128KB        |   157,809.8 ns |    442.24 ns |    392.03 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 128KB        |   211,560.4 ns |    340.52 ns |    318.52 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128KB        |   219,206.0 ns |    344.34 ns |    305.25 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128KB        |   239,193.8 ns |    681.69 ns |    637.66 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128B         |       280.9 ns |      1.25 ns |      1.17 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 128B         |       336.0 ns |      2.56 ns |      2.27 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128B         |       349.1 ns |      6.60 ns |      6.17 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128B         |       359.1 ns |      1.53 ns |      1.36 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 137B         |       528.7 ns |      3.84 ns |      3.59 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 137B         |       658.7 ns |      4.23 ns |      3.96 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 137B         |       667.1 ns |      3.47 ns |      3.24 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 137B         |       682.2 ns |      2.18 ns |      1.93 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1KB          |     1,711.1 ns |      5.83 ns |      5.45 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 1KB          |     2,262.1 ns |      7.24 ns |      6.77 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1KB          |     2,330.9 ns |      6.20 ns |      5.18 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1KB          |     2,487.5 ns |     10.53 ns |      9.34 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1025B        |     1,703.6 ns |      4.98 ns |      3.89 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 1025B        |     2,278.1 ns |      5.39 ns |      4.78 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1025B        |     2,327.4 ns |      7.40 ns |      6.93 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1025B        |     2,482.6 ns |     11.17 ns |      9.90 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 8KB          |    12,442.9 ns |     93.69 ns |     87.64 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 8KB          |    16,633.4 ns |     50.16 ns |     41.89 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 8KB          |    17,152.9 ns |     55.14 ns |     46.04 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 8KB          |    18,567.5 ns |    105.30 ns |     98.49 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128KB        |   193,574.3 ns |    685.39 ns |    607.58 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 128KB        |   261,236.4 ns |    572.80 ns |    507.77 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128KB        |   269,109.6 ns |    681.72 ns |    604.32 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128KB        |   292,113.3 ns |  1,208.97 ns |  1,071.72 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128B         |       239.1 ns |      1.74 ns |      1.62 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 128B         |       309.8 ns |      0.91 ns |      0.71 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128B         |       316.8 ns |      0.74 ns |      0.69 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128B         |       358.5 ns |      1.45 ns |      1.35 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 137B         |       483.6 ns |      1.76 ns |      1.47 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 137B         |       625.9 ns |      2.11 ns |      1.87 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 137B         |       642.5 ns |      1.37 ns |      1.28 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 137B         |       648.0 ns |      1.62 ns |      1.52 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1KB          |     1,673.9 ns |      6.93 ns |      6.48 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 1KB          |     2,217.1 ns |      6.19 ns |      5.79 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1KB          |     2,293.9 ns |      8.36 ns |      7.82 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1KB          |     2,479.9 ns |      8.04 ns |      7.12 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1025B        |     1,661.0 ns |      3.09 ns |      2.42 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 1025B        |     2,222.1 ns |      9.60 ns |      8.02 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1025B        |     2,292.0 ns |      8.13 ns |      7.21 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1025B        |     2,475.7 ns |      7.46 ns |      6.98 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 8KB          |    12,328.6 ns |     57.97 ns |     54.22 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 8KB          |    16,541.3 ns |     34.97 ns |     31.00 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 8KB          |    17,089.1 ns |     29.53 ns |     27.62 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 8KB          |    18,535.1 ns |     59.82 ns |     55.95 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128KB        |   192,377.9 ns |  1,043.24 ns |    975.85 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 128KB        |   261,749.9 ns |    942.72 ns |    787.21 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128KB        |   268,858.2 ns |    788.67 ns |    737.72 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128KB        |   291,561.9 ns |  1,232.59 ns |  1,152.96 ns |     112 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128B**         |       **733.4 ns** |      **6.09 ns** |      **5.40 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128B**         |     **1,053.8 ns** |      **4.79 ns** |      **4.48 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128B         |     1,994.0 ns |      5.66 ns |      5.29 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **137B**         |       **727.0 ns** |      **2.84 ns** |      **2.66 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **137B**         |     **1,054.6 ns** |      **5.53 ns** |      **4.90 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 137B         |     1,990.9 ns |      6.30 ns |      5.58 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1KB**          |     **1,986.3 ns** |     **16.81 ns** |     **14.90 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1KB**          |     **2,524.4 ns** |     **15.43 ns** |     **13.68 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1KB          |     3,832.4 ns |     18.62 ns |     17.42 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1025B**        |     **1,992.2 ns** |     **11.16 ns** |      **9.89 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1025B**        |     **2,544.9 ns** |     **17.34 ns** |     **16.22 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1025B        |     3,832.3 ns |     15.21 ns |     14.23 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **8KB**          |    **10,475.4 ns** |     **54.61 ns** |     **48.41 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **8KB**          |    **12,887.0 ns** |     **67.30 ns** |     **62.95 ns** |    **8360 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 8KB          |    16,694.8 ns |     75.55 ns |     70.67 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128KB**        |   **158,359.6 ns** |    **628.92 ns** |    **557.52 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128KB**        |   **224,102.2 ns** |  **1,307.92 ns** |  **1,159.44 ns** |  **131263 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128KB        |   240,427.0 ns |    670.49 ns |    594.37 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128B**         |       **736.7 ns** |      **2.89 ns** |      **2.41 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128B**         |     **1,064.2 ns** |      **6.80 ns** |      **6.36 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128B         |     1,972.2 ns |      5.59 ns |      4.67 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **137B**         |       **985.7 ns** |     **10.08 ns** |      **9.43 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **137B**         |     **1,302.7 ns** |      **7.74 ns** |      **7.24 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 137B         |     2,267.1 ns |      6.78 ns |      6.01 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1KB**          |     **2,163.6 ns** |     **13.25 ns** |     **12.39 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1KB**          |     **2,766.2 ns** |     **12.98 ns** |     **11.51 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1KB          |     4,098.4 ns |     17.92 ns |     15.88 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1025B**        |     **2,165.6 ns** |     **14.98 ns** |     **14.01 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1025B**        |     **2,745.4 ns** |      **9.40 ns** |      **7.34 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1025B        |     4,113.7 ns |     24.45 ns |     22.87 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **8KB**          |    **12,829.3 ns** |     **65.64 ns** |     **58.19 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **8KB**          |    **15,597.2 ns** |     **71.46 ns** |     **59.67 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 8KB          |    20,125.9 ns |     47.04 ns |     41.70 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128KB**        |   **193,355.1 ns** |    **606.66 ns** |    **567.47 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128KB**        |   **264,196.0 ns** |  **1,287.74 ns** |  **1,204.55 ns** |  **131327 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128KB        |   293,279.2 ns |    909.18 ns |    850.44 ns |     464 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128B         |       226.9 ns |      1.02 ns |      0.91 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 128B         |       251.0 ns |      1.08 ns |      1.01 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128B         |       254.1 ns |      1.24 ns |      1.16 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 137B         |       223.2 ns |      0.98 ns |      0.92 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 137B         |       248.1 ns |      1.05 ns |      0.98 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 137B         |       250.2 ns |      0.97 ns |      0.91 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1KB          |       973.3 ns |      5.95 ns |      5.57 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 1KB          |     1,177.1 ns |      4.03 ns |      3.77 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1KB          |     1,197.4 ns |      4.33 ns |      4.05 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1025B        |       940.6 ns |      3.90 ns |      3.65 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 1025B        |     1,164.8 ns |      3.20 ns |      2.84 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1025B        |     1,194.5 ns |      3.60 ns |      3.37 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 8KB          |     6,157.2 ns |     21.99 ns |     20.57 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 8KB          |     7,881.2 ns |     38.72 ns |     34.32 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 8KB          |     8,186.7 ns |     33.59 ns |     29.77 ns |    1056 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128KB        |    91,242.6 ns |    420.51 ns |    393.34 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 128KB        |   117,746.5 ns |    232.98 ns |    206.53 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128KB        |   122,232.1 ns |    532.14 ns |    497.76 ns |    8136 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128B         |       228.1 ns |      1.07 ns |      0.95 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 128B         |       253.6 ns |      0.90 ns |      0.80 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128B         |       257.5 ns |      1.15 ns |      1.08 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 137B         |       390.7 ns |      1.56 ns |      1.31 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 137B         |       438.5 ns |      1.15 ns |      0.96 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 137B         |       439.1 ns |      1.51 ns |      1.42 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1KB          |     1,029.2 ns |      5.12 ns |      4.54 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 1KB          |     1,304.4 ns |      5.63 ns |      4.99 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1KB          |     1,344.0 ns |      3.66 ns |      3.24 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1025B        |     1,030.4 ns |      3.58 ns |      3.34 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 1025B        |     1,300.7 ns |      3.61 ns |      3.20 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1025B        |     1,340.9 ns |      2.39 ns |      2.12 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 8KB          |     7,240.1 ns |     44.72 ns |     41.83 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 8KB          |     9,291.9 ns |     28.69 ns |     23.96 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 8KB          |     9,730.9 ns |     21.13 ns |     19.76 ns |    1056 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128KB        |   111,985.9 ns |    514.48 ns |    481.25 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 128KB        |   144,611.1 ns |    527.50 ns |    467.61 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128KB        |   151,246.9 ns |    590.11 ns |    492.77 ns |    7656 B |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 128B         |       293.6 ns |      0.64 ns |      0.60 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128B**         |       **348.5 ns** |      **1.12 ns** |      **0.99 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128B**         |       **395.0 ns** |      **0.70 ns** |      **0.65 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 137B         |       292.5 ns |      0.57 ns |      0.51 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **137B**         |       **353.2 ns** |      **2.36 ns** |      **2.21 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **137B**         |       **392.3 ns** |      **1.30 ns** |      **1.22 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 1KB          |     1,396.5 ns |      1.59 ns |      1.49 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1KB**          |     **1,824.8 ns** |     **11.43 ns** |     **10.69 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1KB**          |     **2,029.7 ns** |      **4.95 ns** |      **4.63 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 1025B        |     1,392.9 ns |      1.99 ns |      1.86 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1025B**        |     **1,827.9 ns** |     **10.58 ns** |      **9.89 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1025B**        |     **2,026.5 ns** |      **1.64 ns** |      **1.37 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 8KB          |    10,185.2 ns |     17.98 ns |     16.82 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **8KB**          |    **13,584.8 ns** |     **76.56 ns** |     **71.61 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **8KB**          |    **15,008.3 ns** |     **23.01 ns** |     **20.40 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 128KB        |   160,846.5 ns |    162.10 ns |    143.70 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128KB**        |   **214,611.1 ns** |    **849.79 ns** |    **709.61 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128KB**        |   **238,349.3 ns** |    **405.20 ns** |    **379.02 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | RIPEMD-160 | BouncyCastle                     | 128B         |       672.5 ns |      1.85 ns |      1.73 ns |      96 B |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128B**         |       **979.1 ns** |      **7.55 ns** |      **5.90 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **137B**         |       **666.7 ns** |      **2.20 ns** |      **1.95 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **137B**         |       **989.5 ns** |      **7.09 ns** |      **6.64 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1KB**          |     **3,546.6 ns** |      **6.68 ns** |      **6.25 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1KB**          |     **5,462.5 ns** |     **50.84 ns** |     **47.55 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1025B**        |     **3,554.7 ns** |      **6.50 ns** |      **6.08 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1025B**        |     **5,630.4 ns** |     **33.67 ns** |     **31.50 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **8KB**          |    **26,637.2 ns** |     **87.62 ns** |     **81.96 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **8KB**          |    **40,465.3 ns** |    **237.74 ns** |    **222.38 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **128KB**        |   **423,560.8 ns** |    **767.70 ns** |    **680.55 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128KB**        |   **642,907.4 ns** |  **6,086.52 ns** |  **5,693.34 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128B**         |       **253.0 ns** |      **1.42 ns** |      **1.25 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128B         |       460.4 ns |      1.64 ns |      1.46 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128B**         |       **486.1 ns** |      **3.32 ns** |      **3.11 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **137B**         |       **253.0 ns** |      **1.59 ns** |      **1.49 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 137B         |       462.3 ns |      1.77 ns |      1.66 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **137B**         |       **480.9 ns** |      **1.28 ns** |      **1.20 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1KB**          |     **1,125.2 ns** |      **3.89 ns** |      **3.63 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1KB          |     2,435.4 ns |     15.66 ns |     14.64 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1KB**          |     **2,480.1 ns** |     **17.00 ns** |     **15.90 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1025B**        |     **1,126.1 ns** |      **6.19 ns** |      **5.79 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1025B        |     2,429.1 ns |     10.34 ns |      9.68 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1025B**        |     **2,480.1 ns** |      **6.52 ns** |      **6.10 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **8KB**          |     **8,076.9 ns** |     **42.15 ns** |     **39.43 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 8KB          |    18,133.6 ns |     67.60 ns |     59.93 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **8KB**          |    **18,400.4 ns** |     **95.24 ns** |     **89.08 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128KB**        |   **127,197.0 ns** |    **510.14 ns** |    **477.19 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128KB        |   287,505.5 ns |  1,258.28 ns |  1,176.99 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128KB**        |   **290,858.5 ns** |  **1,473.33 ns** |  **1,378.15 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128B**         |       **578.8 ns** |      **1.91 ns** |      **1.59 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128B**         |       **586.5 ns** |      **3.42 ns** |      **3.20 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **137B**         |       **579.2 ns** |      **3.04 ns** |      **2.84 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **137B**         |       **605.6 ns** |      **3.68 ns** |      **3.27 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1KB**          |     **3,090.7 ns** |     **11.14 ns** |     **10.42 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1KB**          |     **3,185.0 ns** |     **19.98 ns** |     **18.69 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1025B**        |     **3,098.5 ns** |     **21.45 ns** |     **20.06 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1025B**        |     **3,190.4 ns** |     **17.70 ns** |     **16.56 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **8KB**          |    **23,141.6 ns** |     **96.10 ns** |     **89.89 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **8KB**          |    **23,752.9 ns** |    **181.29 ns** |    **169.58 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128KB**        |   **367,379.9 ns** |  **2,887.36 ns** |  **2,700.84 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128KB**        |   **374,731.3 ns** |  **1,490.34 ns** |  **1,394.07 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128B**         |       **129.1 ns** |      **0.33 ns** |      **0.31 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128B         |       570.0 ns |      2.43 ns |      2.28 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128B**         |       **608.9 ns** |      **3.77 ns** |      **3.53 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **137B**         |       **129.4 ns** |      **0.39 ns** |      **0.35 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 137B         |       572.3 ns |      4.68 ns |      4.38 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **137B**         |       **603.6 ns** |      **2.28 ns** |      **1.90 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1KB**          |       **488.6 ns** |      **1.33 ns** |      **1.24 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1KB          |     3,044.9 ns |     13.25 ns |     12.40 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1KB**          |     **3,165.7 ns** |     **23.40 ns** |     **21.89 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1025B**        |       **490.6 ns** |      **2.58 ns** |      **2.41 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1025B        |     3,043.6 ns |     12.04 ns |     10.67 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1025B**        |     **3,162.8 ns** |     **12.19 ns** |     **11.40 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **8KB**          |     **3,305.8 ns** |      **8.35 ns** |      **7.81 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 8KB          |    22,779.3 ns |     59.33 ns |     52.59 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **8KB**          |    **23,541.7 ns** |     **81.86 ns** |     **72.57 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128KB**        |    **51,607.5 ns** |    **130.22 ns** |    **121.80 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128KB        |   361,444.3 ns |  1,028.10 ns |    911.39 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128KB**        |   **373,152.4 ns** |  **1,870.14 ns** |  **1,749.33 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **128B**         |       **372.7 ns** |      **2.45 ns** |      **2.29 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 128B         |       508.5 ns |      2.71 ns |      2.54 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128B**         |       **539.4 ns** |      **2.69 ns** |      **2.51 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **137B**         |       **371.1 ns** |      **1.62 ns** |      **1.51 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 137B         |       506.1 ns |      2.58 ns |      2.41 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **137B**         |       **535.1 ns** |      **2.78 ns** |      **2.46 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1KB**          |     **1,413.3 ns** |     **10.25 ns** |      **9.59 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1KB          |     2,106.1 ns |      8.64 ns |      8.08 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1KB**          |     **2,131.4 ns** |     **11.98 ns** |     **11.21 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1025B**        |     **1,417.5 ns** |      **7.51 ns** |      **7.02 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1025B        |     2,103.8 ns |     10.38 ns |      9.71 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1025B**        |     **2,128.2 ns** |     **10.01 ns** |      **8.87 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **8KB**          |     **9,720.9 ns** |     **57.33 ns** |     **50.82 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                         | **8KB**          |    **14,801.9 ns** |     **76.19 ns** |     **71.27 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **8KB**          |    **14,825.1 ns** |     **31.81 ns** |     **24.83 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-384 | OS Native                           | 128KB        |   152,137.5 ns |    710.61 ns |    664.70 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128KB**        |   **232,581.5 ns** |  **1,159.28 ns** |  **1,084.39 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **128KB**        |   **233,647.6 ns** |    **727.14 ns** |    **680.17 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512 | OS Native                           | 128B         |       371.9 ns |      1.41 ns |      1.25 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                        | 128B         |       502.5 ns |      2.19 ns |      1.83 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128B**         |       **562.0 ns** |      **1.82 ns** |      **1.70 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **137B**         |       **369.4 ns** |      **2.23 ns** |      **1.98 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 137B         |       506.9 ns |      2.62 ns |      2.45 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **137B**         |       **559.9 ns** |      **2.72 ns** |      **2.55 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1KB**          |     **1,406.0 ns** |      **3.34 ns** |      **2.79 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1KB          |     2,136.1 ns |     41.11 ns |     38.45 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1KB**          |     **2,250.8 ns** |     **35.39 ns** |     **31.37 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1025B**        |     **1,425.1 ns** |     **15.57 ns** |     **13.80 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1025B        |     2,195.0 ns |     36.09 ns |     33.75 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1025B**        |     **2,258.0 ns** |     **35.57 ns** |     **33.27 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **8KB**          |     **9,820.9 ns** |    **138.52 ns** |    **129.57 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 8KB          |    15,051.3 ns |    219.61 ns |    205.42 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **8KB**          |    **15,809.9 ns** |    **235.77 ns** |    **220.54 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **128KB**        |   **154,316.1 ns** |  **2,500.08 ns** |  **2,338.58 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 128KB        |   238,017.6 ns |  3,303.83 ns |  3,090.41 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128KB**        |   **247,978.5 ns** |  **4,373.95 ns** |  **4,091.39 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128B**         |       **518.1 ns** |      **7.86 ns** |      **7.36 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128B**         |       **542.2 ns** |      **8.89 ns** |      **8.32 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **137B**         |       **524.4 ns** |      **8.37 ns** |      **7.83 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **137B**         |       **536.7 ns** |      **7.04 ns** |      **6.58 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1KB**          |     **2,137.5 ns** |     **32.20 ns** |     **30.12 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1KB**          |     **2,139.8 ns** |     **14.36 ns** |     **12.73 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1025B**        |     **2,146.6 ns** |     **28.45 ns** |     **26.61 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1025B**        |     **2,147.7 ns** |     **32.85 ns** |     **30.73 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/224 | CryptoHives                     | 8KB          |    14,918.3 ns |    235.23 ns |    220.04 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **8KB**          |    **15,047.4 ns** |    **234.02 ns** |    **218.90 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128KB**        |   **234,771.1 ns** |  **3,713.78 ns** |  **3,473.88 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128KB**        |   **235,074.2 ns** |  **3,090.60 ns** |  **2,890.95 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/256 | BouncyCastle                    | 128B         |       521.8 ns |      8.59 ns |      8.03 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128B**         |       **543.8 ns** |      **8.48 ns** |      **7.94 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **137B**         |       **528.5 ns** |      **8.09 ns** |      **7.57 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **137B**         |       **538.3 ns** |      **8.21 ns** |      **7.68 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1KB**          |     **2,141.5 ns** |     **32.42 ns** |     **30.33 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **1KB**          |     **2,143.6 ns** |     **30.10 ns** |     **28.16 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1025B**        |     **2,151.8 ns** |     **34.17 ns** |     **31.96 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **1025B**        |     **2,161.0 ns** |     **36.92 ns** |     **34.53 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/256 | CryptoHives                     | 8KB          |    15,035.2 ns |    275.05 ns |    257.28 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **8KB**          |    **15,035.8 ns** |    **243.16 ns** |    **227.45 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128KB**        |   **235,655.9 ns** |  **3,240.53 ns** |  **3,031.19 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **128KB**        |   **236,850.7 ns** |  **3,864.59 ns** |  **3,614.94 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128B         |       245.1 ns |      3.52 ns |      3.29 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 128B         |       313.0 ns |      2.57 ns |      2.14 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128B         |       320.2 ns |      1.76 ns |      1.37 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128B         |       365.7 ns |      6.41 ns |      6.00 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 137B         |       241.4 ns |      4.66 ns |      4.58 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 137B         |       311.7 ns |      4.49 ns |      4.20 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 137B         |       322.0 ns |      4.50 ns |      3.99 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 137B         |       362.8 ns |      5.68 ns |      5.31 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1KB          |     1,717.8 ns |     23.74 ns |     22.21 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 1KB          |     2,250.2 ns |      4.55 ns |      3.55 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1KB          |     2,355.6 ns |     40.41 ns |     37.80 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1KB          |     2,491.4 ns |     16.43 ns |     14.56 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1025B        |     1,713.6 ns |     25.06 ns |     23.44 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 1025B        |     2,249.5 ns |     10.74 ns |      8.39 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1025B        |     2,345.3 ns |     38.14 ns |     35.67 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1025B        |     2,508.6 ns |     33.95 ns |     31.75 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 8KB          |    11,537.5 ns |     49.25 ns |     43.66 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 8KB          |    15,528.9 ns |     58.42 ns |     54.64 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 8KB          |    16,251.8 ns |    288.83 ns |    414.23 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 8KB          |    17,446.6 ns |     83.36 ns |     77.98 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128KB        |   183,019.5 ns |    509.70 ns |    476.78 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 128KB        |   245,913.0 ns |    602.37 ns |    563.46 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128KB        |   256,849.3 ns |  1,189.29 ns |  1,112.46 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128KB        |   277,405.3 ns |    701.99 ns |    622.29 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128B         |       237.8 ns |      1.24 ns |      1.10 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128B         |       297.9 ns |      1.05 ns |      0.93 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 128B         |       309.2 ns |      0.76 ns |      0.63 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128B         |       316.9 ns |      1.16 ns |      1.03 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128B         |       357.5 ns |      1.65 ns |      1.46 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 137B         |       485.2 ns |      1.52 ns |      1.27 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 137B         |       524.9 ns |      2.35 ns |      2.08 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 137B         |       631.6 ns |      1.74 ns |      1.63 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 137B         |       644.4 ns |      2.42 ns |      2.26 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 137B         |       649.4 ns |      2.94 ns |      2.75 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1KB          |     1,669.4 ns |      5.17 ns |      4.31 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1KB          |     1,941.5 ns |     14.13 ns |     13.22 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 1KB          |     2,220.5 ns |      9.59 ns |      8.97 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1KB          |     2,285.1 ns |      7.68 ns |      7.18 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1KB          |     2,484.4 ns |     16.46 ns |     15.40 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1025B        |     1,665.8 ns |      4.39 ns |      3.67 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1025B        |     1,941.7 ns |     11.67 ns |     10.92 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 1025B        |     2,221.8 ns |      6.72 ns |      6.29 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1025B        |     2,287.8 ns |      9.72 ns |      8.11 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1025B        |     2,481.1 ns |     10.50 ns |      9.82 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 8KB          |    12,355.2 ns |     34.59 ns |     32.35 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 8KB          |    14,365.4 ns |     36.13 ns |     28.21 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 8KB          |    16,586.6 ns |     63.52 ns |     59.41 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 8KB          |    17,093.0 ns |     61.05 ns |     57.11 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 8KB          |    18,592.5 ns |     75.53 ns |     70.65 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128KB        |   193,487.0 ns |    802.60 ns |    750.75 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128KB        |   226,870.8 ns |    916.07 ns |    856.89 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 128KB        |   260,452.1 ns |  1,003.36 ns |    938.54 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128KB        |   269,075.3 ns |    859.62 ns |    804.09 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128KB        |   292,413.6 ns |    667.52 ns |    521.15 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128B         |       461.1 ns |      2.14 ns |      2.01 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128B         |       528.7 ns |      3.39 ns |      3.17 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 128B         |       604.0 ns |      1.83 ns |      1.71 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128B         |       620.4 ns |      1.47 ns |      1.30 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128B         |       646.8 ns |      2.72 ns |      2.41 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 137B         |       458.2 ns |      2.23 ns |      2.08 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 137B         |       533.5 ns |      2.21 ns |      1.96 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 137B         |       600.0 ns |      1.82 ns |      1.70 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 137B         |       618.1 ns |      1.94 ns |      1.72 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 137B         |       649.4 ns |      2.47 ns |      2.31 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1KB          |     2,024.8 ns |      9.70 ns |      8.10 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1KB          |     2,400.7 ns |      8.70 ns |      8.14 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 1KB          |     2,741.8 ns |      7.85 ns |      6.95 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1KB          |     2,815.3 ns |      6.70 ns |      5.94 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1KB          |     3,055.7 ns |     15.10 ns |     13.39 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1025B        |     2,024.5 ns |      6.06 ns |      5.37 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1025B        |     2,398.3 ns |     21.90 ns |     20.49 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 1025B        |     2,742.4 ns |      8.73 ns |      7.74 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1025B        |     2,806.0 ns |      7.65 ns |      6.39 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1025B        |     3,059.5 ns |      7.83 ns |      6.54 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 8KB          |    15,743.4 ns |     98.19 ns |     87.04 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 8KB          |    18,405.8 ns |     88.95 ns |     78.85 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 8KB          |    21,352.2 ns |     38.32 ns |     35.84 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 8KB          |    21,917.4 ns |     58.79 ns |     52.11 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 8KB          |    23,850.8 ns |     56.62 ns |     50.19 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128KB        |   251,092.8 ns |  1,301.33 ns |  1,217.27 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128KB        |   293,624.7 ns |  1,302.49 ns |  1,218.35 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 128KB        |   339,157.0 ns |    778.37 ns |    728.09 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128KB        |   349,602.1 ns |    731.72 ns |    648.65 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128KB        |   378,242.3 ns |  1,138.13 ns |  1,064.61 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128B         |       433.7 ns |      1.94 ns |      1.82 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128B         |       528.6 ns |      4.35 ns |      4.07 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 128B         |       576.9 ns |      1.71 ns |      1.43 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128B         |       595.3 ns |      2.14 ns |      1.79 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128B         |       652.8 ns |      3.02 ns |      2.82 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 137B         |       431.9 ns |      1.25 ns |      1.17 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 137B         |       527.6 ns |      1.88 ns |      1.67 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 137B         |       572.7 ns |      1.62 ns |      1.44 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 137B         |       590.8 ns |      2.51 ns |      2.09 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 137B         |       650.4 ns |      2.70 ns |      2.53 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1KB          |     3,011.2 ns |     13.98 ns |     13.08 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1KB          |     3,541.4 ns |     11.69 ns |      9.76 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 1KB          |     4,083.7 ns |     12.23 ns |     11.44 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1KB          |     4,197.7 ns |     11.95 ns |      9.98 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1KB          |     4,538.7 ns |     25.82 ns |     24.15 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1025B        |     3,012.7 ns |     15.42 ns |     14.42 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1025B        |     3,553.0 ns |     10.40 ns |      9.73 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 1025B        |     4,083.5 ns |     10.87 ns |      9.07 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1025B        |     4,197.9 ns |     12.49 ns |     11.68 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1025B        |     4,556.4 ns |     37.49 ns |     35.07 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 8KB          |    22,533.0 ns |    100.34 ns |     93.86 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 8KB          |    26,346.8 ns |     56.26 ns |     46.98 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 8KB          |    30,488.4 ns |    126.92 ns |    118.72 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 8KB          |    31,571.9 ns |    112.21 ns |    104.97 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 8KB          |    34,335.5 ns |    170.54 ns |    159.52 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128KB        |   359,543.5 ns |  1,813.77 ns |  1,607.86 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128KB        |   421,874.6 ns |  2,311.95 ns |  2,162.60 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 128KB        |   488,360.3 ns |  5,114.39 ns |  3,992.98 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128KB        |   502,853.9 ns |  2,090.31 ns |  1,853.01 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128KB        |   556,034.7 ns |  2,525.87 ns |  2,362.70 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128B         |       270.8 ns |      1.04 ns |      0.87 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 128B         |       340.6 ns |      2.09 ns |      1.96 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128B         |       349.1 ns |      0.66 ns |      0.61 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128B         |       357.0 ns |      1.42 ns |      1.33 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128B         |       377.9 ns |      2.16 ns |      2.02 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 137B         |       273.2 ns |      0.99 ns |      0.93 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 137B         |       336.7 ns |      1.28 ns |      1.14 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 137B         |       346.1 ns |      1.71 ns |      1.60 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 137B         |       357.7 ns |      1.09 ns |      0.97 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 137B         |       379.7 ns |      1.97 ns |      1.84 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1KB          |     1,522.8 ns |      3.66 ns |      3.06 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1KB          |     1,800.5 ns |      8.47 ns |      7.92 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 1KB          |     2,013.1 ns |      5.71 ns |      5.06 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1KB          |     2,076.1 ns |      7.51 ns |      6.27 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1KB          |     2,190.0 ns |      8.03 ns |      7.12 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1025B        |     1,534.7 ns |     11.29 ns |     10.56 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1025B        |     1,801.8 ns |     10.69 ns |      9.99 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 1025B        |     2,015.5 ns |      6.05 ns |      5.66 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1025B        |     2,072.5 ns |      5.75 ns |      5.38 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1025B        |     2,181.1 ns |      8.36 ns |      6.98 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 8KB          |     9,981.4 ns |     45.36 ns |     42.43 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 8KB          |    11,718.2 ns |     46.57 ns |     43.56 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 8KB          |    13,409.5 ns |     30.93 ns |     27.42 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 8KB          |    13,824.8 ns |     35.71 ns |     31.66 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 8KB          |    15,001.3 ns |     38.68 ns |     34.29 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128KB        |   158,299.4 ns |    655.24 ns |    580.85 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128KB        |   184,945.6 ns |  1,096.49 ns |  1,025.66 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 128KB        |   211,351.4 ns |    317.46 ns |    296.95 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128KB        |   219,184.5 ns |    545.58 ns |    483.64 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128KB        |   238,752.3 ns |    850.05 ns |    753.55 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128B         |       278.6 ns |      0.88 ns |      0.78 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 128B         |       333.8 ns |      4.64 ns |      4.11 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128B         |       356.3 ns |      2.57 ns |      2.41 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128B         |       358.0 ns |      1.70 ns |      1.59 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128B         |       379.0 ns |      1.77 ns |      1.57 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 137B         |       525.0 ns |      3.53 ns |      3.30 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 137B         |       618.3 ns |      2.85 ns |      2.52 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 137B         |       660.0 ns |      4.71 ns |      3.93 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 137B         |       666.6 ns |      1.30 ns |      1.08 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 137B         |       680.5 ns |      2.38 ns |      2.11 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1KB          |     1,705.6 ns |      9.35 ns |      8.29 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1KB          |     2,038.9 ns |      9.00 ns |      8.42 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 1KB          |     2,258.3 ns |     10.15 ns |      9.49 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1KB          |     2,330.0 ns |     11.17 ns |     10.45 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1KB          |     2,488.3 ns |     13.82 ns |     12.93 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1025B        |     1,700.8 ns |      6.00 ns |      5.01 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1025B        |     2,036.8 ns |      9.89 ns |      9.25 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 1025B        |     2,259.9 ns |      5.55 ns |      4.92 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1025B        |     2,332.1 ns |     12.34 ns |     10.94 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1025B        |     2,491.0 ns |      8.67 ns |      8.11 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 8KB          |    12,375.8 ns |     51.01 ns |     47.71 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 8KB          |    14,449.6 ns |     65.15 ns |     60.94 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 8KB          |    16,613.1 ns |     46.76 ns |     43.74 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 8KB          |    17,127.6 ns |     59.10 ns |     52.39 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 8KB          |    18,621.9 ns |     75.82 ns |     70.92 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128KB        |   194,397.6 ns |  1,078.83 ns |    956.36 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128KB        |   226,592.0 ns |  1,194.10 ns |  1,116.96 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 128KB        |   260,885.5 ns |    913.82 ns |    854.78 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128KB        |   268,978.9 ns |  1,231.37 ns |  1,091.58 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128KB        |   292,726.1 ns |  1,107.72 ns |    981.96 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SM3 | BouncyCastle                            | 128B         |       820.6 ns |      2.73 ns |      2.55 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                             | **128B**         |       **939.0 ns** |      **0.86 ns** |      **0.67 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **137B**         |       **819.8 ns** |      **2.12 ns** |      **1.88 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **137B**         |       **944.8 ns** |      **2.08 ns** |      **1.94 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1KB**          |     **4,369.8 ns** |     **11.78 ns** |     **11.02 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1KB**          |     **5,160.0 ns** |     **12.52 ns** |     **11.09 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1025B**        |     **4,382.3 ns** |     **23.65 ns** |     **22.12 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1025B**        |     **5,174.2 ns** |     **16.24 ns** |     **15.19 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **8KB**          |    **33,327.9 ns** |    **102.85 ns** |     **96.20 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **8KB**          |    **38,877.1 ns** |     **80.15 ns** |     **71.05 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **128KB**        |   **528,881.2 ns** |  **1,822.70 ns** |  **1,615.77 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **128KB**        |   **617,100.8 ns** |  **1,606.31 ns** |  **1,341.34 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | Streebog-256 | CryptoHives                    | 128B         |     2,412.4 ns |      8.05 ns |      7.53 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128B**         |     **3,429.1 ns** |     **21.41 ns** |     **20.03 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128B         |     4,251.8 ns |     31.81 ns |     29.76 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **137B**         |     **2,429.7 ns** |      **5.41 ns** |      **5.06 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **137B**         |     **3,425.2 ns** |      **8.82 ns** |      **7.36 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 137B         |     4,350.4 ns |     18.05 ns |     16.88 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1KB**          |     **9,477.9 ns** |     **12.17 ns** |     **11.38 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1KB**          |    **12,678.5 ns** |     **54.24 ns** |     **50.73 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1KB          |    16,378.1 ns |     57.29 ns |     50.78 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1025B**        |     **9,188.5 ns** |     **21.87 ns** |     **20.45 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1025B**        |    **12,667.0 ns** |     **80.10 ns** |     **74.92 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1025B        |    16,527.8 ns |     74.14 ns |     69.35 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **8KB**          |    **62,191.0 ns** |    **202.02 ns** |    **188.97 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **8KB**          |    **86,604.0 ns** |    **545.60 ns** |    **510.36 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 8KB          |   111,435.1 ns |    444.15 ns |    415.46 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **128KB**        |   **991,517.1 ns** |  **7,128.27 ns** |  **6,667.79 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128KB**        | **1,350,615.9 ns** |  **4,337.09 ns** |  **3,386.12 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128KB        | 1,744,523.1 ns |  7,074.49 ns |  6,617.48 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128B**         |     **2,424.0 ns** |      **3.25 ns** |      **2.72 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128B**         |     **3,345.9 ns** |     **11.24 ns** |     **10.51 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128B         |     4,261.4 ns |     19.38 ns |     18.13 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **137B**         |     **2,436.6 ns** |      **5.31 ns** |      **4.97 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **137B**         |     **3,353.9 ns** |     **14.16 ns** |     **13.24 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 137B         |     4,280.4 ns |     22.79 ns |     21.32 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1KB**          |     **9,123.4 ns** |     **18.35 ns** |     **15.32 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1KB**          |    **12,610.9 ns** |     **56.63 ns** |     **52.97 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1KB          |    16,176.6 ns |     61.21 ns |     57.25 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1025B**        |     **9,094.9 ns** |     **16.10 ns** |     **15.06 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1025B**        |    **12,567.2 ns** |     **55.13 ns** |     **51.57 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1025B        |    19,041.9 ns |    104.67 ns |     97.91 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **8KB**          |    **63,297.7 ns** |    **162.18 ns** |    **143.77 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **8KB**          |    **86,054.3 ns** |    **361.30 ns** |    **301.70 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 8KB          |   112,171.5 ns |    622.59 ns |    582.37 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128KB**        |   **948,838.5 ns** |  **2,080.14 ns** |  **1,843.99 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128KB**        | **1,352,934.9 ns** |  **4,756.70 ns** |  **4,216.69 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128KB        | 1,744,385.9 ns |  4,638.08 ns |  4,111.54 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128B         |       179.7 ns |      0.69 ns |      0.65 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 128B         |       207.4 ns |      1.00 ns |      0.94 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128B         |       213.2 ns |      0.80 ns |      0.71 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 137B         |       177.9 ns |      0.88 ns |      0.78 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 137B         |       203.7 ns |      0.42 ns |      0.39 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 137B         |       205.3 ns |      0.55 ns |      0.51 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1KB          |       876.6 ns |      3.69 ns |      3.27 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 1KB          |     1,108.8 ns |      4.30 ns |      4.02 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1KB          |     1,146.9 ns |      7.67 ns |      6.40 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1025B        |       878.1 ns |      4.09 ns |      3.82 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 1025B        |     1,107.5 ns |      3.43 ns |      3.21 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1025B        |     1,144.3 ns |      3.13 ns |      2.93 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 8KB          |     5,456.9 ns |     24.69 ns |     23.10 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 8KB          |     7,000.8 ns |     18.54 ns |     15.48 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 8KB          |     7,311.4 ns |     13.98 ns |     12.40 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128KB        |    85,558.6 ns |    534.15 ns |    499.65 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 128KB        |   111,470.7 ns |    284.41 ns |    252.12 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128KB        |   115,426.6 ns |    181.09 ns |    160.53 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128B         |       188.5 ns |      1.40 ns |      1.31 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 128B         |       209.2 ns |      0.46 ns |      0.43 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128B         |       214.6 ns |      0.57 ns |      0.51 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 137B         |       338.3 ns |      1.30 ns |      1.16 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 137B         |       386.2 ns |      0.89 ns |      0.83 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 137B         |       396.2 ns |      1.43 ns |      1.34 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1KB          |       960.5 ns |      4.74 ns |      4.43 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 1KB          |     1,228.2 ns |      3.11 ns |      2.91 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1KB          |     1,281.0 ns |      3.75 ns |      3.13 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1025B        |       959.3 ns |      6.08 ns |      5.69 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 1025B        |     1,227.2 ns |      4.94 ns |      4.62 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1025B        |     1,275.9 ns |      3.10 ns |      2.90 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 8KB          |     6,674.9 ns |     26.70 ns |     24.97 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 8KB          |     8,719.7 ns |     22.04 ns |     19.54 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 8KB          |     9,080.1 ns |     20.19 ns |     17.90 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128KB        |   104,028.8 ns |    377.38 ns |    353.00 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 128KB        |   135,799.6 ns |    440.92 ns |    390.87 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128KB        |   142,221.1 ns |    178.04 ns |    166.54 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128B**         |     **1,386.4 ns** |      **6.18 ns** |      **5.78 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128B**         |     **5,064.9 ns** |     **31.57 ns** |     **29.53 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **137B**         |     **1,379.1 ns** |      **3.89 ns** |      **3.45 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **137B**         |     **5,043.7 ns** |     **20.86 ns** |     **19.51 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1KB**          |     **7,633.5 ns** |     **42.33 ns** |     **39.59 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1KB**          |    **30,962.8 ns** |    **199.09 ns** |    **186.23 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1025B**        |     **7,717.2 ns** |     **42.20 ns** |     **39.47 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1025B**        |    **30,772.0 ns** |    **110.26 ns** |    **103.14 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **8KB**          |    **57,644.7 ns** |    **252.72 ns** |    **236.39 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **8KB**          |   **238,620.6 ns** |  **1,175.17 ns** |  **1,099.25 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128KB**        |   **923,722.0 ns** |  **3,750.51 ns** |  **3,508.23 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128KB**        | **3,778,732.2 ns** | **17,467.25 ns** | **16,338.87 ns** |     **232 B** |
```
