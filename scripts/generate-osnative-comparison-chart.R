#!/usr/bin/env Rscript
# Generate a comparison chart showing OS Native vs CryptoHives implementations
# For algorithms where both implementations exist
# Usage: Rscript generate-osnative-comparison-chart.R <results_dir> <output_file> [size]

suppressPackageStartupMessages({
  library(ggplot2)
  library(dplyr)
  library(stringr)
  library(tidyr)
})

args <- commandArgs(trailingOnly = TRUE)
if (length(args) < 2) {
  cat("Usage: Rscript generate-osnative-comparison-chart.R <results_dir> <output_file> [size]\n")
  quit(status = 1)
}

results_dir <- args[1]
output_file <- args[2]
target_size <- if (length(args) >= 3) args[3] else "1KB"

# Implementation groups
cryptohives_impls <- c("Managed", "AVX2", "AVX512F", "Ssse3", "Sse2", "Native")
osnative_impl <- "OS Native"

cat(sprintf("Scanning directory: %s\n", results_dir))
cat(sprintf("Target size: %s\n", target_size))

# Find all benchmark markdown files
md_files <- list.files(results_dir, pattern = "Benchmark-report\\.md$", full.names = TRUE)
cat(sprintf("Found %d benchmark files\n", length(md_files)))

# Function to extract algorithm name from filename
extract_algorithm <- function(filename) {
  basename <- tools::file_path_sans_ext(basename(filename))
  algo <- str_replace(basename, "-report$", "")
  algo <- str_replace(algo, "Benchmark$", "")
  return(algo)
}

# Function to parse markdown table from a file
parse_markdown_file <- function(filepath) {
  lines <- readLines(filepath, warn = FALSE)
  
  # Find header line containing | Description ... Mean ... |
  header_idx <- which(grepl("^[|].*Description.*Mean", lines, perl = TRUE))
  if (length(header_idx) == 0) return(NULL)
  header_idx <- header_idx[1]
  
  header_line <- lines[header_idx]
  headers <- str_trim(str_split(header_line, fixed("|"))[[1]])
  headers <- headers[headers != ""]
  
  data_start <- header_idx + 2
  data_rows <- c()
  for (i in data_start:length(lines)) {
    line <- lines[i]
    if (!grepl("^[|]", line, perl = TRUE)) break
    if (grepl("^[|]-", line, perl = TRUE)) next
    data_rows <- c(data_rows, line)
  }
  
  if (length(data_rows) == 0) return(NULL)
  
  parse_row <- function(row) {
    cells <- str_trim(str_split(row, fixed("|"))[[1]])
    cells <- cells[cells != ""]
    if (length(cells) >= length(headers)) return(cells[1:length(headers)])
    return(NULL)
  }
  
  parsed <- lapply(data_rows, parse_row)
  parsed <- parsed[!sapply(parsed, is.null)]
  if (length(parsed) == 0) return(NULL)
  
  df <- as.data.frame(do.call(rbind, parsed), stringsAsFactors = FALSE)
  colnames(df) <- headers
  return(df)
}

# Function to extract implementation from description
get_implementation <- function(desc) {
  if (str_detect(desc, "·")) {
    parts <- str_trim(str_split(desc, "·")[[1]])
    if (length(parts) >= 3) return(parts[3])
  }
  if (str_detect(desc, "_")) {
    parts <- str_split(desc, "_")[[1]]
    if (length(parts) >= 2) {
      impl <- parts[length(parts)]
      if (impl == "DotNet") return("OS Native")
      return(impl)
    }
  }
  return("Unknown")
}

# Function to parse time string to nanoseconds
parse_time_ns <- function(time_str) {
  time_str <- str_trim(time_str)
  # Remove commas from numbers (e.g., "2,851.9 ns" -> "2851.9 ns")
  time_str <- gsub(",", "", time_str)
  
  if (str_detect(time_str, "ns$")) {
    return(as.numeric(str_replace(time_str, " ?ns$", "")))
  } else if (str_detect(time_str, "μs$") || str_detect(time_str, "us$")) {
    return(as.numeric(str_replace(time_str, " ?(μs|us)$", "")) * 1000)
  } else if (str_detect(time_str, "ms$")) {
    return(as.numeric(str_replace(time_str, " ?ms$", "")) * 1000000)
  } else if (str_detect(time_str, "s$")) {
    return(as.numeric(str_replace(time_str, " ?s$", "")) * 1000000000)
  }
  return(NA)
}

# Function to parse size to bytes
parse_size_bytes <- function(size_str) {
  size_str <- str_trim(size_str)
  if (str_detect(size_str, "KB$")) {
    return(as.numeric(str_replace(size_str, "KB$", "")) * 1024)
  } else if (str_detect(size_str, "MB$")) {
    return(as.numeric(str_replace(size_str, "MB$", "")) * 1024 * 1024)
  } else if (str_detect(size_str, "B$")) {
    return(as.numeric(str_replace(size_str, "B$", "")))
  }
  return(as.numeric(size_str))
}

# Collect data from all files
all_data <- data.frame()

for (md_file in md_files) {
  algo_name <- extract_algorithm(md_file)
  df <- parse_markdown_file(md_file)
  
  if (is.null(df)) next
  
  size_col <- names(df)[str_detect(tolower(names(df)), "size|data")]
  if (length(size_col) == 0) next
  size_col <- size_col[1]
  
  mean_col <- names(df)[str_detect(names(df), "^Mean$")]
  if (length(mean_col) == 0) next
  
  df$Algorithm <- algo_name
  df$Implementation <- sapply(df$Description, get_implementation)
  df$SizeBytes <- sapply(df[[size_col]], parse_size_bytes)
  df$MeanNs <- sapply(df[[mean_col]], parse_time_ns)
  df$TargetSize <- df[[size_col]]
  
  all_data <- rbind(all_data, df[, c("Algorithm", "Implementation", "TargetSize", "SizeBytes", "MeanNs")])
}

cat(sprintf("Collected %d total rows\n", nrow(all_data)))

# Filter to target size
filtered <- all_data %>%
  filter(TargetSize == target_size) %>%
  filter(!is.na(MeanNs), MeanNs > 0) %>%
  mutate(ThroughputMBps = (SizeBytes / MeanNs) * 1000)

# Find fastest CryptoHives per algorithm
fastest_cryptohives <- filtered %>%
  filter(Implementation %in% cryptohives_impls) %>%
  group_by(Algorithm) %>%
  slice_max(ThroughputMBps, n = 1) %>%
  ungroup() %>%
  mutate(Source = "CryptoHives") %>%
  select(Algorithm, ThroughputMBps, Source, Implementation)

# Find OS Native per algorithm
osnative_data <- filtered %>%
  filter(Implementation == osnative_impl) %>%
  mutate(Source = "OS Native") %>%
  select(Algorithm, ThroughputMBps, Source, Implementation)

cat(sprintf("CryptoHives implementations: %d\n", nrow(fastest_cryptohives)))
cat(sprintf("OS Native implementations: %d\n", nrow(osnative_data)))

# Find algorithms that have BOTH implementations
common_algos <- intersect(fastest_cryptohives$Algorithm, osnative_data$Algorithm)
cat(sprintf("Algorithms with both implementations: %d\n", length(common_algos)))

if (length(common_algos) == 0) {
  cat("No algorithms have both CryptoHives and OS Native implementations!\n")
  quit(status = 1)
}

# Filter to common algorithms
chart_data <- bind_rows(
  fastest_cryptohives %>% filter(Algorithm %in% common_algos),
  osnative_data %>% filter(Algorithm %in% common_algos)
)

# Determine unit
max_throughput <- max(chart_data$ThroughputMBps, na.rm = TRUE)
if (max_throughput >= 1000) {
  throughput_unit <- "GB/s"
  chart_data$Throughput <- chart_data$ThroughputMBps / 1000
} else {
  throughput_unit <- "MB/s"
  chart_data$Throughput <- chart_data$ThroughputMBps
}

cat(sprintf("Using throughput unit: %s\n", throughput_unit))

# Order by OS Native throughput (descending)
algo_order <- osnative_data %>%
  filter(Algorithm %in% common_algos) %>%
  arrange(desc(ThroughputMBps)) %>%
  pull(Algorithm)

chart_data$Algorithm <- factor(chart_data$Algorithm, levels = algo_order)
chart_data$Source <- factor(chart_data$Source, levels = c("OS Native", "CryptoHives"))

# Calculate speedup/slowdown for annotations
comparison <- chart_data %>%
  select(Algorithm, Source, Throughput) %>%
  pivot_wider(names_from = Source, values_from = Throughput) %>%
  mutate(
    Ratio = CryptoHives / `OS Native`,
    Label = case_when(
      Ratio >= 1 ~ sprintf("+%.0f%%", (Ratio - 1) * 100),
      TRUE ~ sprintf("%.0f%%", (Ratio - 1) * 100)
    )
  )

# Generate chart
p <- ggplot(chart_data, aes(x = Algorithm, y = Throughput, fill = Source)) +
  geom_bar(stat = "identity", position = position_dodge(width = 0.8), width = 0.7) +
  geom_text(aes(label = sprintf("%.2f", Throughput), group = Source), 
            position = position_dodge(width = 0.8),
            vjust = -0.3, size = 3, fontface = "bold") +
  labs(
    title = "OS Native vs CryptoHives Implementation Comparison",
    subtitle = sprintf("Data size: %s | Higher is better", target_size),
    x = "Algorithm",
    y = sprintf("Throughput (%s)", throughput_unit),
    fill = "Implementation"
  ) +
  scale_fill_manual(values = c(
    "OS Native" = "#E15759",
    "CryptoHives" = "#4E79A7"
  )) +
  theme_minimal(base_size = 12) +
  theme(
    plot.title = element_text(hjust = 0.5, face = "bold", size = 16),
    plot.subtitle = element_text(hjust = 0.5, size = 12, color = "gray40"),
    axis.text.x = element_text(angle = 45, hjust = 1, size = 10),
    axis.title = element_text(face = "bold"),
    legend.position = "top",
    panel.grid.major.x = element_blank(),
    panel.grid.minor = element_blank(),
    panel.border = element_rect(color = "gray80", fill = NA, linewidth = 0.5)
  )

# Save plot
cat(sprintf("Saving chart to: %s\n", output_file))
ggsave(output_file, plot = p, width = 12, height = 7, dpi = 300, bg = "white")

cat(sprintf("✓ Comparison chart generated for %d algorithms!\n", length(common_algos)))

# Print comparison summary
cat("\nPerformance comparison (CryptoHives vs OS Native):\n")
comparison %>%
  arrange(desc(Ratio)) %>%
  mutate(Status = if_else(Ratio >= 1, "✓ Faster", "✗ Slower")) %>%
  select(Algorithm, `OS Native`, CryptoHives, Label, Status) %>%
  print(n = 20)
